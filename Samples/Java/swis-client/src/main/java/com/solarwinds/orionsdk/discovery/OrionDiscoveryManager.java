package com.solarwinds.orionsdk.discovery;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.solarwinds.orionsdk.swis_client.ISwisClient;

public class OrionDiscoveryManager {
	private static final String ORION_DISCOVERY = "Orion.Discovery";
	private ISwisClient swis;

	public OrionDiscoveryManager(ISwisClient swis) {
		this.swis = swis;
	}

	public String createCorePluginConfiguration(CorePluginContext context) {
		return swis.invoke(ORION_DISCOVERY, "CreateCorePluginConfiguration", context).getAsString();
	}

	public int startDiscovery(StartDiscoveryContext context) {
		return swis.invoke(ORION_DISCOVERY, "StartDiscovery", context).getAsInt();
	}

	public DiscoveryStatus checkDiscoveryStatus(final int profileId) {
		List<Map<String, Object>> results = swis.query(
				"SELECT Status FROM Orion.DiscoveryProfiles WHERE ProfileID = @profileId",
				param("profileId", profileId));
		if (results.isEmpty())
			return DiscoveryStatus.Unknown;
		
		return DiscoveryStatus.values()[(int) (long) (Long) results.get(0).get("Status")];
	}

	public DiscoveryResults waitForCompletion(final int profileId) throws InterruptedException {
		DiscoveryStatus status;
		do {
			Thread.sleep(1000);
			status = checkDiscoveryStatus(profileId);
		} while (status == DiscoveryStatus.InProgress);

		List<Map<String, Object>> log = swis.query(
				"SELECT Result, ResultDescription, ErrorMessage, BatchID FROM Orion.DiscoveryLogs WHERE ProfileID = @profileId",
				param("profileId", profileId));

		DiscoveryResults results = new DiscoveryResults();
		results.setResult(DiscoveryStatus.values()[(int) (long) (Long) log.get(0).get("Result")]);
		results.setResultDescription((String) log.get(0).get("ResultDescription"));
		results.setErrorMessage((String) log.get(0).get("ErrorMessage"));

		if (results.getResult() == DiscoveryStatus.Finished) {
			String batchId = (String) log.get(0).get("BatchID");
			List<Map<String, Object>> items = swis.query(
					"SELECT EntityType, DisplayName, NetObjectID FROM Orion.DiscoveryLogItems WHERE BatchID = @batchId",
					param("batchId", batchId));
			for (Map<String, Object> item : items) {
				DiscoveredObject obj = new DiscoveredObject();
				obj.setEntityType((String) item.get("EntityType"));
				obj.setDisplayName((String) item.get("DisplayName"));
				obj.setNetObjectId((String) item.get("NetObjectID"));
				results.getDiscoveredObjects().add(obj);
			}
		}

		return results;
	}

	private Map<String, Object> param(String name, Object value) {
		Map<String, Object> data = new HashMap<String, Object>();
		data.put(name, value);
		return data;
	}
}
