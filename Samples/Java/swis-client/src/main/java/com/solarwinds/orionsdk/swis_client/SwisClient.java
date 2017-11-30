package com.solarwinds.orionsdk.swis_client;

import java.lang.reflect.Type;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;
import java.text.NumberFormat;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import javax.net.ssl.HostnameVerifier;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSession;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import com.google.gson.JsonParser;
import com.google.gson.JsonPrimitive;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.UniformInterfaceException;
import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.api.client.config.ClientConfig;
import com.sun.jersey.api.client.config.DefaultClientConfig;
import com.sun.jersey.api.client.filter.HTTPBasicAuthFilter;
import com.sun.jersey.client.urlconnection.HTTPSProperties;

public class SwisClient implements ISwisClient {

	private static final String MIME_JSON = "application/json";
	private String hostname;
	private String username;
	private String password;

	private static Gson gson = new GsonBuilder().registerTypeAdapter(Map.class, new MapDeserializer())
			.registerTypeAdapter(List.class, new ListDeserializer()).setDateFormat("yyyy-MM-dd HH:mm:ss")
			.serializeNulls().create();

	public SwisClient(String hostname, String username, String password) {
		this.hostname = hostname;
		this.username = username;
		this.password = password;
	}

	private static Object toObject(JsonElement v) {
		JsonPrimitive prim = (JsonPrimitive) v;
		if (prim.isNumber()) {
			try {
				return NumberFormat.getInstance().parse(v.getAsString());
			} catch (ParseException e) {
				throw new RuntimeException("Failed to parse number: " + v.getAsString(), e);
			}
		} else if (prim.isString()) {
			return prim.getAsString();
		} else if (prim.isBoolean()) {
			return prim.getAsBoolean();
		}

		throw new RuntimeException("Unexpected json primitive: " + prim.toString());
	}

	private static class MapDeserializer implements JsonDeserializer<Map<String, Object>> {
		public Map<String, Object> deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
				throws JsonParseException {
			Map<String, Object> m = new LinkedHashMap<String, Object>();
			JsonObject jo = json.getAsJsonObject();
			for (Entry<String, JsonElement> mx : jo.entrySet()) {
				String key = mx.getKey();
				JsonElement v = mx.getValue();
				if (v.isJsonArray()) {
					m.put(key, gson.fromJson(v, List.class));
				} else if (v.isJsonPrimitive()) {
					m.put(key, toObject(v));
				} else if (v.isJsonObject()) {
					m.put(key, gson.fromJson(v, Map.class));
				}

			}
			return m;
		}
	}

	private static class ListDeserializer implements JsonDeserializer<List<Object>> {
		public List<Object> deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context)
				throws JsonParseException {
			List<Object> m = new ArrayList<Object>();
			JsonArray arr = json.getAsJsonArray();
			for (JsonElement jsonElement : arr) {
				if (jsonElement.isJsonObject()) {
					m.add(gson.fromJson(jsonElement, Map.class));
				} else if (jsonElement.isJsonArray()) {
					m.add(gson.fromJson(jsonElement, List.class));
				} else if (jsonElement.isJsonPrimitive()) {
					m.add(toObject(jsonElement));
				}
			}
			return m;
		}
	}

	public List<Map<String, Object>> query(String queryText, Map<String, Object> queryParameters) {
		WebResource webResource = getClient("Query");
		String queryRequest = gson.toJson(new QueryRequest(queryText, queryParameters));
		String response = post(webResource, queryRequest);
		List<Map<String, Object>> results = gson.fromJson(response, QueryResponse.class).getResults();
		return results;
	}

	public JsonElement invoke(String entityType, String verb, Object... arguments) {
		WebResource webResource = getClient("Invoke/" + entityType + "/" + verb);
		String invokeRequest = gson.toJson(arguments);
		String response = post(webResource, invokeRequest);
		JsonElement jsonResponse = new JsonParser().parse(response);
		return jsonResponse;
	}

	private String post(WebResource webResource, String requestBody) {
		try {
			return webResource.accept(MIME_JSON).type(MIME_JSON).post(String.class, requestBody);
		} catch (UniformInterfaceException e) {
			throw SwisException.fromUniformInterfaceException(e);
		}
	}

	public String create(String entityType, Map<String, Object> properties) {
		WebResource webResource = getClient("Create/" + entityType);
		String createRequest = gson.toJson(properties);
		String response = webResource.accept(MIME_JSON).type(MIME_JSON).post(String.class, createRequest);
		JsonElement jsonResponse = new JsonParser().parse(response);
		return jsonResponse.getAsString();
	}

	public void update(String uri, Map<String, Object> properties) {
		WebResource webResource = getClient(uri);
		String updateRequest = gson.toJson(properties);
		post(webResource, updateRequest);
	}

	public void update(List<String> uris, Map<String, Object> properties) {
		WebResource webResource = getClient("BulkUpdate");
		String updateRequest = gson.toJson(new BulkUpdateRequest(uris, properties));
		post(webResource, updateRequest);
	}

	public void delete(String uri) {
		WebResource webResource = getClient(uri);
		try {
			webResource.accept(MIME_JSON).type(MIME_JSON).delete();
		} catch (UniformInterfaceException e) {
			throw SwisException.fromUniformInterfaceException(e);
		}
	}

	public void delete(List<String> uris) {
		WebResource webResource = getClient("BulkDelete");
		String deleteRequest = gson.toJson(new BulkDeleteRequest(uris));
		post(webResource, deleteRequest);
	}

	private WebResource getClient(String relativeUrl) {
		SSLContext ctx = trustAllCertificates();

		ClientConfig clientConfig = new DefaultClientConfig();
		clientConfig.getProperties().put(HTTPSProperties.PROPERTY_HTTPS_PROPERTIES,
				new HTTPSProperties(new HostnameVerifier() {
					public boolean verify(String s, SSLSession sslSession) {
						return true;
					}
				}, ctx));
		Client client = Client.create(clientConfig);
		client.addFilter(new HTTPBasicAuthFilter(username, password));

		String url = "https://" + hostname + ":17778/SolarWinds/InformationService/v3/Json/" + relativeUrl;
		WebResource webResource = client.resource(url);
		return webResource;
	}

	private static SSLContext trustAllCertificates() {
		// Create a trust manager that does not validate certificate chains
		TrustManager[] trustAllCerts = new TrustManager[] { new X509TrustManager() {
			public X509Certificate[] getAcceptedIssuers() {
				return new X509Certificate[0];
			}

			public void checkClientTrusted(X509Certificate[] certs, String authType) {
			}

			public void checkServerTrusted(X509Certificate[] certs, String authType) {
			}
		} };

		// Install the all-trusting trust manager
		try {
			SSLContext sc = SSLContext.getInstance("TLS");
			sc.init(null, trustAllCerts, new SecureRandom());
			HttpsURLConnection.setDefaultSSLSocketFactory(sc.getSocketFactory());
			return sc;
		} catch (Exception e) {
			return null;
		}
	}
}
