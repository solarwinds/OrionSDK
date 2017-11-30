package com.solarwinds.orionsdk.swis_client;

import java.util.List;

class BulkDeleteRequest {
	@SuppressWarnings("unused")
	private List<String> uris;

	public BulkDeleteRequest(List<String> uris) {
		this.uris = uris;
	}
}
