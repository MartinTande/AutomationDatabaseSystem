using System.Data;
using System.Security.AccessControl;
using Microsoft.Data.SqlClient;

namespace AutomationSystem.Classes
{
    class TagObject
    {
        public int ObjectId { get; set; }
        public string? ObjectName { get; set; }
        public string? ObjectType { get; set; }
        public string? Hierarchy_1 { get; set; }
        public string? Hierarchy_2 {  get; set; }
        public string? EasGroup { get; set; }
        public string? Otd { get; set; }

        string connectionString = DatabaseAccess.GetConnectionString();

        public void SaveData(string  objectName, string objectType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("SaveObject", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ObjectName", objectName));
                    command.Parameters.Add(new SqlParameter("@ObjectType", objectType));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Error when inserting data into database");
                }
            }
        }

        public List<TagObject> GetTagObjects()
        {
            List<TagObject> objectList = new List<TagObject>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string selectSQL = "select ObjectId, ObjectName, ObjectType, Hierarchy1, Hierarchy2, EasGroup, Otd from GetTagObjectData";
                    SqlCommand command = new SqlCommand(selectSQL, connection);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            TagObject tagObject = new TagObject();

                            tagObject.ObjectId = Convert.ToInt32(dataReader["ObjectId"]);
                            tagObject.ObjectName = dataReader["ObjectName"].ToString();
                            tagObject.ObjectType = dataReader["ObjectType"].ToString();
                            tagObject.Hierarchy_1 = dataReader["Hierarchy1"].ToString();
                            tagObject.Hierarchy_2 = dataReader["Hierarchy2"].ToString();
                            tagObject.EasGroup = dataReader["EasGroup"].ToString();
                            tagObject.Otd = dataReader["Otd"].ToString();

                            objectList.Add(tagObject);
                        }
                    }
                    connection.Close();
                }

                catch
                {
                    MessageBox.Show("Error when retrieving data from database");
                }
            }
            return objectList;
        }

        public void CreateTagObject(TagObject tagObject)
        {
            ExecuteStoredProcedureOnTagObject(tagObject, "CreateObject");
        }

        public TagObject GetTagObjectData(int objectId)
        {
            TagObject tagObject = new TagObject();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string selectSQL = $"select ObjectId, ObjectName, ObjectType, Hierarchy1, Hierarchy2, EasGroup, Otd from GetTagObjectData where ObjectId = {objectId}";
                    SqlCommand command = new SqlCommand(selectSQL, connection);
                    
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            tagObject.ObjectId = Convert.ToInt32(dataReader["ObjectId"]);
                            tagObject.ObjectName = dataReader["ObjectName"].ToString();
                            tagObject.ObjectType = dataReader["ObjectType"].ToString();
                            tagObject.Hierarchy_1 = dataReader["Hierarchy1"].ToString();
                            tagObject.Hierarchy_2 = dataReader["Hierarchy2"].ToString();
                            tagObject.EasGroup = dataReader["EasGroup"].ToString();
                            tagObject.Otd = dataReader["Otd"].ToString();
                        }
                    }
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Error when retrieving data from database");
                }
            }
            return tagObject;
        }

        public void EditTagObject(TagObject tagObject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UpdateObject", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ObjectId", tagObject.ObjectId));
                    command.Parameters.Add(new SqlParameter("@ObjectName", tagObject.ObjectName));
                    command.Parameters.Add(new SqlParameter("@ObjectType", tagObject.ObjectType));
                    command.Parameters.Add(new SqlParameter("@Hierarchy1", tagObject.Hierarchy_1));
                    command.Parameters.Add(new SqlParameter("@Hierarchy2", tagObject.Hierarchy_2));
                    command.Parameters.Add(new SqlParameter("@EasGroup", tagObject.EasGroup));
                    command.Parameters.Add(new SqlParameter("@Otd", tagObject.Otd));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Error when inserting data into database");
                }
            }
        }

        private void ExecuteStoredProcedureOnTagObject(TagObject tagObject, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(storedProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ObjectName", tagObject.ObjectName));
                    command.Parameters.Add(new SqlParameter("@ObjectType", tagObject.ObjectType));
                    command.Parameters.Add(new SqlParameter("@Hierarchy1", tagObject.Hierarchy_1));
                    command.Parameters.Add(new SqlParameter("@Hierarchy2", tagObject.Hierarchy_2));
                    command.Parameters.Add(new SqlParameter("@EasGroup", tagObject.EasGroup));
                    command.Parameters.Add(new SqlParameter("@Otd", tagObject.Otd));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Error when inserting data into database");
                }
            }

        }
    }
}
