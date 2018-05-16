package com.solarwinds.orionsdk.discovery;

public class IpAddress {
	private String address;

	public IpAddress(String address) {
		setAddress(address);
	}
	
	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}
}
