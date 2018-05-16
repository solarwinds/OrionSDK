package com.solarwinds.orionsdk.discovery;

public class Credential {
	private int credentialId;
	private int order;

	public Credential(int credentialId, int order) {
		setCredentialId(credentialId);
		setOrder(order);
	}

	public int getCredentialId() {
		return credentialId;
	}

	public void setCredentialId(int credentialId) {
		this.credentialId = credentialId;
	}

	public int getOrder() {
		return order;
	}

	public void setOrder(int order) {
		this.order = order;
	}
}
