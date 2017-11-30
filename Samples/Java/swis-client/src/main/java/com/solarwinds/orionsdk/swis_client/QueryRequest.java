package com.solarwinds.orionsdk.swis_client;

import java.util.Map;

class QueryRequest {
	@SuppressWarnings("unused")
	private String query;
	@SuppressWarnings("unused")
	private Map<String, Object> parameters;

	public QueryRequest(String query, Map<String, Object> parameters) {
		this.query = query;
		this.parameters = parameters;
	}
}