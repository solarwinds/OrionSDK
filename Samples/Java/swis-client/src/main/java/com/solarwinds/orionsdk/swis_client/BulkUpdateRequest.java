package com.solarwinds.orionsdk.swis_client;

import java.util.List;
import java.util.Map;

class BulkUpdateRequest {
	@SuppressWarnings("unused")
	private List<String> uris;
	@SuppressWarnings("unused")
	private Map<String, Object> properties;

	public BulkUpdateRequest(List<String> uris, Map<String, Object> properties) {
		this.uris = uris;
		this.properties = properties;
	}
}
