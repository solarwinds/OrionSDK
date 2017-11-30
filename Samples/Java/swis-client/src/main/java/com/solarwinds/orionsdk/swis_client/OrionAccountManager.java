package com.solarwinds.orionsdk.swis_client;

import java.util.Map;

public class OrionAccountManager {
	private static final String ACCOUNTS = "Orion.Accounts";
	private ISwisClient swis;

	public OrionAccountManager(ISwisClient swis) {
		this.swis = swis;
	}

	public void createOrionAccount(String accountId, String password) {
		swis.invoke(ACCOUNTS, "CreateOrionAccount", accountId, password);
	}

	public enum WindowsAccountType {
		User, Group
	}

	public void createWindowsAccount(WindowsAccountType accountType, String userOrGroupName) {
		createWindowsAccount(accountType, userOrGroupName, "", "");
	}
	
	public void createWindowsAccount(WindowsAccountType accountType, String userOrGroupName, String adAdminUser,
			String adAdminPassword) {
		swis.invoke(ACCOUNTS, "CreateWindowsAccount", accountType == WindowsAccountType.User ? 2 : 3, userOrGroupName,
				adAdminUser, adAdminPassword);
	}

	public void updateAccount(String accountId, Map<String, Object> properties) {
		swis.invoke(ACCOUNTS, "UpdateAccount", accountId, properties);
	}

	public void deleteAccount(String accountId) {
		swis.invoke(ACCOUNTS, "DeleteAccount", accountId);
	}

	public void changePassword(String accountId, String newPassword) {
		swis.invoke(ACCOUNTS, "ChangePassword", accountId, newPassword);
	}

}
