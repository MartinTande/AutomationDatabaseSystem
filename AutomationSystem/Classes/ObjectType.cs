using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace AutomationSystem.Classes
{
    public class ObjectType
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int ObjectTypeId {  get; set; }
        public string ObjectTypeName { get; set; }

        public List<ObjectType> GetObjectTypes()
        {
            List<ObjectType> objectTypeList = new List<ObjectType>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "select ObjectTypeId, ObjectType from OBJECT_TYPE order by ObjectType";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader != null )
            {
                while (dataReader.Read())
                {
                    ObjectType objectType = new ObjectType();

                    objectType.ObjectTypeId = Convert.ToInt32(dataReader["ObjectTypeId"]);
                    objectType.ObjectTypeName = dataReader["ObjectType"].ToString();
                    
                    objectTypeList.Add(objectType);
                }
            }

            connection.Close();
            return objectTypeList;
        }

    }
}
