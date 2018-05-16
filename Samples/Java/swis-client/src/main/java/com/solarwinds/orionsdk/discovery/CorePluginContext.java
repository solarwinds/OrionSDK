package com.solarwinds.orionsdk.discovery;

import java.util.ArrayList;
import java.util.List;

public class CorePluginContext {
	private final List<IpAddress> bulkList = new ArrayList<IpAddress>();
	private final List<Credential> credentials = new ArrayList<Credential>();
	private int wmiRetriesCount = 0;
	private int wmiRetryIntervalMiliseconds = 1000;

	public int getWmiRetriesCount() {
		return wmiRetriesCount;
	}

	public void setWmiRetriesCount(int wmiRetriesCount) {
		this.wmiRetriesCount = wmiRetriesCount;
	}

	public int getWmiRetryIntervalMiliseconds() {
		return wmiRetryIntervalMiliseconds;
	}

	public void setWmiRetryIntervalMiliseconds(int wmiRetryIntervalMiliseconds) {
		this.wmiRetryIntervalMiliseconds = wmiRetryIntervalMiliseconds;
	}

	public List<Credential> getCredentials() {
		return credentials;
	}

	public List<IpAddress> getBulkList() {
		return bulkList;
	}
}
