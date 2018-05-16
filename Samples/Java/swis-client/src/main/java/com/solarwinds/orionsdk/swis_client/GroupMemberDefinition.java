package com.solarwinds.orionsdk.swis_client;

public class GroupMemberDefinition {
	private String name;
	private String definition;

	public GroupMemberDefinition(String name, String definition) {
		setName(name);
		setDefinition(definition);
	}
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	public String getDefinition() {
		return definition;
	}

	public void setDefinition(String definition) {
		this.definition = definition;
	}
}
