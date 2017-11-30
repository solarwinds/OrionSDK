package com.solarwinds.orionsdk.swis_client;

import java.util.List;
import java.util.Map;

class QueryResponse {
	private List<Map<String, Object>> results;

	public List<Map<String, Object>> getResults() {
		return results;
	}
}