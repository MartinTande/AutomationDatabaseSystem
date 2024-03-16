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
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("SaveObject", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ObjectName", objectName));
                command.Parameters.Add(new SqlParameter("@ObjectType", objectType));

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Error when inserting data into database");
            }
        }

        public List<TagObject> GetTagObjects()
        {
            List<TagObject> objectList = new List<TagObject>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                string selectSQL = "select ObjectId, ObjectName, ObjectType, Hierarchy1, Hierarchy2, EasGroup, Otd from GetTagObjectData";

                connection.Open();

                SqlCommand command = new SqlCommand(selectSQL, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        TagObject tagObject = new TagObject();

                        ObjectId = Convert.ToInt32(dataReader["ObjectId"]);
                        ObjectName = dataReader["ObjectName"].ToString();
                        ObjectType = dataReader["ObjectType"].ToString();
                        Hierarchy_1 = dataReader["Hierarchy1"].ToString();
                        Hierarchy_2 = dataReader["Hierarchy2"].ToString();
                        EasGroup = dataReader["EasGroup"].ToString();
                        Otd = dataReader["Otd"].ToString();

                        objectList.Add(tagObject);
                    }
                }
                connection.Close();
            }

            catch
            {
                MessageBox.Show("Error when retrieving data from database");
            }

            return objectList;
        }

        public void CreateTagObject(TagObject tagObject)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("CreateObject", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ObjectName", tagObject.ObjectName));
                command.Parameters.Add(new SqlParameter("@ObjectType", tagObject.ObjectType));
                command.Parameters.Add(new SqlParameter("@Hierarchy1", tagObject.Hierarchy_1));
                command.Parameters.Add(new SqlParameter("@Hierarchy2", tagObject.Hierarchy_2));
                command.Parameters.Add(new SqlParameter("@EasGroup", tagObject.EasGroup));
                command.Parameters.Add(new SqlParameter("@Otd", tagObject.Otd));

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
