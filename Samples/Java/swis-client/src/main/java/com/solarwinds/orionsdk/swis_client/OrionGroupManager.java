package com.solarwinds.orionsdk.swis_client;

public class OrionGroupManager {
	private ISwisClient swis;

	public OrionGroupManager(ISwisClient swis) {
		this.swis = swis;
	}

	public void createGroup(String name, int refreshIntervalSeconds, GroupRollupMode rollupMode, String description,
			boolean pollingEnabled, Iterable<GroupMemberDefinition> members) {
		swis.invoke("Orion.Container", "CreateContainer", name, "Core", refreshIntervalSeconds, rollupMode.getValue(),
				description, pollingEnabled, members);
	}
}
