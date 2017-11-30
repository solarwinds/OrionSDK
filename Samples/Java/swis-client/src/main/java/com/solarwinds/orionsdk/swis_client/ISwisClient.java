package com.solarwinds.orionsdk.swis_client;

import java.util.List;
import java.util.Map;

import com.google.gson.JsonElement;

public interface ISwisClient {

	List<Map<String, Object>> query(String queryText, Map<String, Object> queryParameters);

	JsonElement invoke(String entityType, String verb, Object... arguments);

	String create(String entityType, Map<String, Object> properties);

	void update(String uri, Map<String, Object> properties);

	void update(List<String> uris, Map<String, Object> properties);

	void delete(String uri);

	void delete(List<String> uris);

}