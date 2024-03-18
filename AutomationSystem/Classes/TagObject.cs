using System.Data;
using System.Security.AccessControl;
using Microsoft.Data.SqlClient;

namespace AutomationSystem.Classes
{
    class TagObject
    {
        public int Id { get; set; }
        public int SfiNumber { get; set; }
        public string? MainEqNumber { get; set; }
        public string? EqNumber { get; set; }
        public string? ObjectDescription { get; set; }
        public string? ObjectType { get; set; }
        public string? Hierarchy_1 { get; set; }
        public string? Hierarchy_2 {  get; set; }
        public string? EasGroup { get; set; }
        public string? Otd { get; set; }
        public string? AcknowledgeAllowed { get; set; }
        public string? AlwaysVisible { get; set; }

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
                    string selectSQL = "select * from GetTagObjectData";
                    SqlCommand command = new SqlCommand(selectSQL, connection);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            TagObject tagObject = new TagObject();

                            tagObject.Id = Convert.ToInt32(dataReader["ObjectId"]);
                            tagObject.SfiNumber = Convert.ToInt32(dataReader["SfiNumber"]);
                            tagObject.MainEqNumber = dataReader["MainEqNumber"].ToString();
                            tagObject.EqNumber = dataReader["EqNumber"].ToString();
                            tagObject.ObjectDescription = dataReader["Description"].ToString();
                            tagObject.ObjectType = dataReader["ObjectType"].ToString();
                            tagObject.Hierarchy_1 = dataReader["Hierarchy1"].ToString();
                            tagObject.Hierarchy_2 = dataReader["Hierarchy2"].ToString();
                            tagObject.EasGroup = dataReader["EasGroup"].ToString();
                            tagObject.Otd = dataReader["AcknowledgeAllowed"].ToString();
                            tagObject.Otd = dataReader["AlwaysVisible"].ToString();

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

        public void CreateTagObject(TagObject newTagObject)
        {
            InsertDataIntoDatabase(newTagObject, "CreateObject");
        }

        public TagObject GetTagObjectData(int objectId)
        {
            TagObject tagObject = new TagObject();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string selectSQL = $"select * from GetTagObjectData where ObjectId = {objectId}";

                    SqlCommand command = new SqlCommand(selectSQL, connection);
                    
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader != null)
                    {
                        while (dataReader.Read())
                        {
                            tagObject.Id = Convert.ToInt32(dataReader["ObjectId"]);
                            tagObject.SfiNumber = Convert.ToInt32(dataReader["SfiNumber"]);
                            tagObject.MainEqNumber = dataReader["MainEqNumber"].ToString();
                            tagObject.EqNumber = dataReader["EqNumber"].ToString();
                            tagObject.ObjectDescription = dataReader["Description"].ToString();
                            tagObject.ObjectType = dataReader["ObjectType"].ToString();
                            tagObject.Hierarchy_1 = dataReader["Hierarchy1"].ToString();
                            tagObject.Hierarchy_2 = dataReader["Hierarchy2"].ToString();
                            tagObject.EasGroup = dataReader["EasGroup"].ToString();
                            tagObject.Otd = dataReader["AcknowledgeAllowed"].ToString();
                            tagObject.Otd = dataReader["AlwaysVisible"].ToString();
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

        public void EditTagObject(TagObject updatedTagObject)
        {
            InsertDataIntoDatabase(updatedTagObject, "UpdateObject");
        }
       
        public void DeleteTagObject(int selectedTagObjectId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("DeleteObject", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ObjectId", selectedTagObjectId));

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

        private void InsertDataIntoDatabase(TagObject tagObject, string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@SfiNumber", tagObject.SfiNumber));
                    command.Parameters.Add(new SqlParameter("@MainEqNumber", tagObject.MainEqNumber));
                    command.Parameters.Add(new SqlParameter("@EqNumber", tagObject.EqNumber));
                    command.Parameters.Add(new SqlParameter("@EqNumber", tagObject.ObjectDescription));
                    command.Parameters.Add(new SqlParameter("@ObjectType", tagObject.ObjectType));
                    command.Parameters.Add(new SqlParameter("@Hierarchy1", tagObject.Hierarchy_1));
                    command.Parameters.Add(new SqlParameter("@Hierarchy2", tagObject.Hierarchy_2));
                    command.Parameters.Add(new SqlParameter("@EasGroup", tagObject.EasGroup));
                    command.Parameters.Add(new SqlParameter("@Otd", tagObject.Otd));
                    command.Parameters.Add(new SqlParameter("@Otd", tagObject.AcknowledgeAllowed));
                    command.Parameters.Add(new SqlParameter("@Otd", tagObject.AlwaysVisible));

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
