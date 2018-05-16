package com.solarwinds.orionsdk.discovery;

import java.util.ArrayList;
import java.util.List;

public class StartDiscoveryContext {
	private String name;
	private int engineId = 1;
	private int jobTimeoutSeconds = 3600;
	private int searchTimeoutMiliseconds = 5000;
	private int snmpTimeoutMiliseconds = 5000;
	private int snmpRetries = 2;
	private int repeatIntervalMiliseconds = 1800;
	private int snmpPort = 161;
	private int hopCount = 0;
	private SnmpVersion preferredSnmpVersion = SnmpVersion.SNMP2c;
	private boolean disableIcmp = false;
	private boolean allowDuplicateNodes = false;
	private boolean isAutoImport = true;
	private boolean isHidden = true;
	private List<PluginConfiguration> pluginConfigurations = new ArrayList<PluginConfiguration>();

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getEngineId() {
		return engineId;
	}

	public void setEngineId(int engineId) {
		this.engineId = engineId;
	}

	public int getJobTimeoutSeconds() {
		return jobTimeoutSeconds;
	}

	public void setJobTimeoutSeconds(int jobTimeoutSeconds) {
		this.jobTimeoutSeconds = jobTimeoutSeconds;
	}

	public int getSearchTimeoutMiliseconds() {
		return searchTimeoutMiliseconds;
	}

	public void setSearchTimeoutMiliseconds(int searchTimeoutMiliseconds) {
		this.searchTimeoutMiliseconds = searchTimeoutMiliseconds;
	}

	public int getSnmpTimeoutMiliseconds() {
		return snmpTimeoutMiliseconds;
	}

	public void setSnmpTimeoutMiliseconds(int snmpTimeoutMiliseconds) {
		this.snmpTimeoutMiliseconds = snmpTimeoutMiliseconds;
	}

	public int getSnmpRetries() {
		return snmpRetries;
	}

	public void setSnmpRetries(int snmpRetries) {
		this.snmpRetries = snmpRetries;
	}

	public int getRepeatIntervalMiliseconds() {
		return repeatIntervalMiliseconds;
	}

	public void setRepeatIntervalMiliseconds(int repeatIntervalMiliseconds) {
		this.repeatIntervalMiliseconds = repeatIntervalMiliseconds;
	}

	public int getSnmpPort() {
		return snmpPort;
	}

	public void setSnmpPort(int snmpPort) {
		this.snmpPort = snmpPort;
	}

	public int getHopCount() {
		return hopCount;
	}

	public void setHopCount(int hopCount) {
		this.hopCount = hopCount;
	}

	public SnmpVersion getPreferredSnmpVersion() {
		return preferredSnmpVersion;
	}

	public void setPreferredSnmpVersion(SnmpVersion preferredSnmpVersion) {
		this.preferredSnmpVersion = preferredSnmpVersion;
	}

	public boolean isDisableIcmp() {
		return disableIcmp;
	}

	public void setDisableIcmp(boolean disableIcmp) {
		this.disableIcmp = disableIcmp;
	}

	public boolean isAllowDuplicateNodes() {
		return allowDuplicateNodes;
	}

	public void setAllowDuplicateNodes(boolean allowDuplicateNodes) {
		this.allowDuplicateNodes = allowDuplicateNodes;
	}

	public boolean isAutoImport() {
		return isAutoImport;
	}

	public void setAutoImport(boolean isAutoImport) {
		this.isAutoImport = isAutoImport;
	}

	public boolean isHidden() {
		return isHidden;
	}

	public void setHidden(boolean isHidden) {
		this.isHidden = isHidden;
	}

	public List<PluginConfiguration> getPluginConfigurations() {
		return pluginConfigurations;
	}

	public void setPluginConfigurations(List<PluginConfiguration> pluginConfigurations) {
		this.pluginConfigurations = pluginConfigurations;
	}
}
