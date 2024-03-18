﻿using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using AutomationSystem.Classes;

namespace AutomationSystem.Categories
{
    public class ObjectType : ICategory<ObjectType>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> objectTypeNameList = new List<string>();

                connection.Open();

                string sqlQuery = "select ObjectTypeId, ObjectTypeName from OBJECT_TYPE order by ObjectTypeName";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        ObjectType objectType = new ObjectType();

                        objectType.Id = Convert.ToInt32(dataReader["ObjectTypeId"]);
                        objectType.Name = dataReader["ObjectTypeName"].ToString();

                        objectTypeNameList.Add(objectType.Name);
                    }
                }

                connection.Close();
                return objectTypeNameList;
            }
        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }

    }
}
