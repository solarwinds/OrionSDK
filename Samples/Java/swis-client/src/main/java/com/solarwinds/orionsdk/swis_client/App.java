package com.solarwinds.orionsdk.swis_client;

public class App {

	private static final String HOSTNAME = "orion.local";
	private static final String USERNAME = "admin";
	private static final String PASSWORD = "";

	public static void main(String[] args) {
		ISwisClient swis = new SwisClient(HOSTNAME, USERNAME, PASSWORD);
		Demo demo = new Demo(swis);

		demo.testQuery();
//		demo.testInvoke();
//		demo.testCreateOrionAccount();
//		demo.testChangePassword();
//		demo.testCreateWindowsAccount();
//		demo.testGrantUserAdminRights();
//		demo.testDeleteUser();
	}
}
