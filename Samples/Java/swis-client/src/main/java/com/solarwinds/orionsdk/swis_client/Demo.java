package com.solarwinds.orionsdk.swis_client;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.google.gson.JsonElement;
import com.solarwinds.orionsdk.swis_client.OrionAccountManager.WindowsAccountType;

public class Demo {
	private ISwisClient swis;
	private OrionAccountManager accounts;
	private OrionGroupManager groups;

	public Demo(ISwisClient swis) {
		this.swis = swis;
		this.accounts = new OrionAccountManager(swis);
		this.groups = new OrionGroupManager(swis);
	}

	public void testQuery() {
		List<Map<String, Object>> results = swis.query("SELECT NodeID, Caption FROM Orion.Nodes", null);

		for (Map<String, Object> row : results) {
			System.out.println(String.format("NodeID=%s, Caption=%s", row.get("NodeID"), row.get("Caption")));
		}
	}

	public void testInvoke() {
		JsonElement aliases = swis.invoke("Metadata.Entity", "GetAliases", "SELECT B.Caption FROM Orion.Nodes B");
		System.out.println(aliases.toString());
	}

	public void testCreateOrionAccount() {
		accounts.createOrionAccount("bob", "swordfish");
		System.out.println("Created account bob");
	}

	public void testChangePassword() {
		accounts.changePassword("bob", "12345");
		System.out.println("Changed bob's password to 12345");
	}

	public void testCreateWindowsAccount() {
		accounts.createWindowsAccount(WindowsAccountType.User, "DOMAIN\\user");
		System.out.println("Authorized AD account DOMAIN\\user");
	}

	public void testGrantUserAdminRights() {
		Map<String, Object> props = new HashMap<String, Object>();
		props.put(OrionAccountPropertyName.AllowAdmin, true);
		accounts.updateAccount("bob", props);
		System.out.println("bob is now an admin");
	}

	public void testDeleteUser() {
		accounts.deleteAccount("bob");
		System.out.println("bob is gone");
	}

	public void testCreateGroup() {
		List<GroupMemberDefinition> members = new ArrayList<GroupMemberDefinition>();
		members.add(new GroupMemberDefinition("Cisco Devices", "filter:/Orion.Nodes[Vendor='Cisco']"));
		members.add(new GroupMemberDefinition("Windows Devices", "filter:/Orion.Nodes[Vendor='Windows']"));

		groups.createGroup("Sample Java Group", 60, GroupRollupMode.Mixed, "Group created by Java sample", true,
				members);
	}
}
