package com.solarwinds.orionsdk.discovery;

public class DiscoveredObject {
	private String entityType;
	private String displayName;
	private String netObjectId;

	public String getEntityType() {
		return entityType;
	}

	public void setEntityType(String entityType) {
		this.entityType = entityType;
	}

	public String getDisplayName() {
		return displayName;
	}

	public void setDisplayName(String displayName) {
		this.displayName = displayName;
	}

	public String getNetObjectId() {
		return netObjectId;
	}

	public void setNetObjectId(String netObjectId) {
		this.netObjectId = netObjectId;
	}
}
