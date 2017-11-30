package com.solarwinds.orionsdk.swis_client;

public class ExceptionResponse {
	private String Message;
	private String ExceptionType;
	private String FullException;

	public String getMessage() {
		return Message;
	}

	public String getExceptionType() {
		return ExceptionType;
	}
	
	public String getFullException() {
		return FullException;
	}
}
