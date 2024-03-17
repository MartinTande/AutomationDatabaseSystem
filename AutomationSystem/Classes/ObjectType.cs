using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace AutomationSystem.Classes
{
    public class ObjectType : ICategory<ObjectType>
    {
        string connectionString = DatabaseAccess.GetConnectionString();
        public int Id {  get; set; }
        public string? Name { get; set; }

        public List<string> GetNames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> objectTypeList = new List<string>();

                connection.Open();

                string sqlQuery = "select ObjectTypeId, ObjectType from OBJECT_TYPE order by ObjectType";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        ObjectType objectType = new ObjectType();

                        objectType.Id = Convert.ToInt32(dataReader["ObjectTypeId"]);
                        objectType.Name = dataReader["ObjectType"].ToString();

                        objectTypeList.Add(objectType.Name);
                    }
                }

                connection.Close();
                return objectTypeList;
            }
        }

        public List<string> GetNames(string category)
        {
            throw new NotImplementedException();
        }

        public List<ObjectType> GetTypes()
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

                    objectType.Id = Convert.ToInt32(dataReader["ObjectTypeId"]);
                    objectType.Name = dataReader["ObjectType"].ToString();
                    
                    objectTypeList.Add(objectType);
                }
            }

            connection.Close();
            return objectTypeList;
        }

    }
}
