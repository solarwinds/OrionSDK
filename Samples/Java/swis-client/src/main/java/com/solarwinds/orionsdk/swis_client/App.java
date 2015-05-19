package com.solarwinds.orionsdk.swis_client;

import java.security.KeyManagementException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;

import javax.net.ssl.HostnameVerifier;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSession;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;

import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.WebResource;
import com.sun.jersey.api.client.config.ClientConfig;
import com.sun.jersey.api.client.config.DefaultClientConfig;
import com.sun.jersey.api.client.filter.HTTPBasicAuthFilter;
import com.sun.jersey.client.urlconnection.HTTPSProperties;

public class App {

	private static final String HOSTNAME = "localhost";
	private static final String USERNAME = "admin";
	private static final String PASSWORD = "";

	public static void main(String[] args) throws JSONException, NoSuchAlgorithmException, KeyManagementException {
		System.out.println("Hello World!");

		SSLContext ctx = trustAllCertificates();

		ClientConfig clientConfig = new DefaultClientConfig();
		clientConfig.getProperties().put(HTTPSProperties.PROPERTY_HTTPS_PROPERTIES,
				new HTTPSProperties(new HostnameVerifier() {
					public boolean verify(String s, SSLSession sslSession) {
						return true;
					}
				}, ctx));
		Client client = Client.create(clientConfig);
		client.addFilter(new HTTPBasicAuthFilter(USERNAME, PASSWORD));

		WebResource webResource = client.resource("https://" + HOSTNAME
				+ ":17778/SolarWinds/InformationService/v3/Json/Query");

		JSONObject queryRequest = new JSONObject();
		queryRequest.put("query", "SELECT NodeID, Caption FROM Orion.Nodes");

		JSONObject response = webResource.accept("application/json").type("application/json")
				.post(JSONObject.class, queryRequest);

		System.out.println(response);

		JSONArray results = response.getJSONArray("results");
		for (int i = 0; i < results.length(); ++i)
		{
			JSONObject result = results.getJSONObject(i);
			int nodeId = result.getInt("NodeID");
			String caption = result.getString("Caption");
			System.out.println(String.format("NodeID=%d, Caption=%s", nodeId, caption));
		}
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
