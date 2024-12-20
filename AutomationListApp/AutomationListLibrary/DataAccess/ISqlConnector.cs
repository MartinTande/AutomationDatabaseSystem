﻿namespace AutomationListLibrary.DataAccess;

public interface ISqlConnector
{
    Task<List<T>> ReadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName = "Default");
    Task WriteDataAsync<T>(string storedProcedure, T parameters, string connectionStringName = "Default");
	List<T> ReadData<T, U>(string storedProcedure, U parameters);
	void WriteData<T>(string storedProcedure, T parameters);
}