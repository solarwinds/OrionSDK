package com.solarwinds.orionsdk.swis_client;

public enum GroupRollupMode {
	Mixed(0), Worst(1), Best(2);
	
	private final int value;

	private GroupRollupMode(int value) {
		this.value = value;
	}

	public int getValue() {
		return value;
	}
}
