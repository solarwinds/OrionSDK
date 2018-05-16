package com.solarwinds.orionsdk.discovery;

import java.util.ArrayList;
import java.util.List;

public class DiscoveryResults {
	public DiscoveryStatus getResult() {
		return result;
	}

	public void setResult(DiscoveryStatus result) {
		this.result = result;
	}

	public String getResultDescription() {
		return resultDescription;
	}

	public void setResultDescription(String resultDescription) {
		this.resultDescription = resultDescription;
	}

	public String getErrorMessage() {
		return errorMessage;
	}

	public void setErrorMessage(String errorMessage) {
		this.errorMessage = errorMessage;
	}

	public List<DiscoveredObject> getDiscoveredObjects() {
		return discoveredObjects;
	}

	private DiscoveryStatus result;
	private String resultDescription;
	private String errorMessage;
	private final List<DiscoveredObject> discoveredObjects = new ArrayList<DiscoveredObject>();
}
