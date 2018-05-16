package com.solarwinds.orionsdk.discovery;

public class PluginConfiguration {
	private String pluginConfigurationItem;

	public PluginConfiguration(String item) {
		setPluginConfigurationItem(item);
	}
	
	public String getPluginConfigurationItem() {
		return pluginConfigurationItem;
	}

	public void setPluginConfigurationItem(String pluginConfigurationItem) {
		this.pluginConfigurationItem = pluginConfigurationItem;
	}
}
