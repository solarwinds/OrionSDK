package com.solarwinds.orionsdk.swis_client;

import com.google.gson.Gson;
import com.sun.jersey.api.client.UniformInterfaceException;

public class SwisException extends RuntimeException {

	private static final long serialVersionUID = -6753798366427400378L;

	public SwisException(String message, Throwable cause) {
		super(message, cause);
	}

	public SwisException(String message, String serverExceptionType, String serverFullException, Throwable cause) {
		super(message, cause);
	}

	public static RuntimeException fromUniformInterfaceException(UniformInterfaceException e) {
		try {
			String responseText = e.getResponse().getEntity(String.class);
			try {
				ExceptionResponse exceptionResponse = new Gson().fromJson(responseText, ExceptionResponse.class);
				return new SwisException(exceptionResponse.getMessage(), exceptionResponse.getExceptionType(),
						exceptionResponse.getFullException(), e);
			} catch (Exception ex) {
				return new SwisException(responseText, e);
			}
		} catch (Exception ex) {
			return e;
		}
	}
}
