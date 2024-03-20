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
        public string? Hierarchy_1 { get; set; }
        public string? Hierarchy_2 {  get; set; }
        public string? VduGroup { get; set; }
        public string? AlarmGroup { get; set; }
        public string? Otd { get; set; }
        public string? AcknowledgeAllowed { get; set; }
        public string? AlwaysVisible { get; set; }
        public string? Node { get; set; }
        public string? Cabinet { get; set; }
        public string? DataBlock { get; set; }

        string connectionString = DatabaseAccess.GetConnectionString();


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
                            tagObject.ObjectDescription = dataReader["ObjectDescription"].ToString();
                            tagObject.Hierarchy_1 = dataReader["Hierarchy1Name"].ToString();
                            tagObject.Hierarchy_2 = dataReader["Hierarchy2Name"].ToString();
                            tagObject.VduGroup = dataReader["VduGroupName"].ToString();
                            tagObject.AlarmGroup = dataReader["AlarmGroupName"].ToString();
                            tagObject.Otd = dataReader["OtdName"].ToString();
                            tagObject.AcknowledgeAllowed = dataReader["AcknowledgeAllowedLocation"].ToString();
                            tagObject.AlwaysVisible = dataReader["AlwaysVisibleLocation"].ToString();
                            tagObject.Node = dataReader["NodeName"].ToString();
                            tagObject.Cabinet = dataReader["CabinetName"].ToString();
                            tagObject.DataBlock = dataReader["DataBlockName"].ToString();

                            objectList.Add(tagObject);
                        }
                    }
                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error when retrieving data from database: " + ex.Message);
                }
            }
            return objectList;
        }

        public void CreateTagObject(TagObject newTagObject)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("CreateObject", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@SfiNumber", newTagObject.SfiNumber));
                    command.Parameters.Add(new SqlParameter("@MainEqNumber", newTagObject.MainEqNumber));
                    command.Parameters.Add(new SqlParameter("@EqNumber", newTagObject.EqNumber));
                    command.Parameters.Add(new SqlParameter("@ObjectDescription", newTagObject.ObjectDescription));
                    command.Parameters.Add(new SqlParameter("@Hierarchy1Name", newTagObject.Hierarchy_1));
                    command.Parameters.Add(new SqlParameter("@Hierarchy2Name", newTagObject.Hierarchy_2));
                    command.Parameters.Add(new SqlParameter("@VduGroupName", newTagObject.VduGroup));
                    command.Parameters.Add(new SqlParameter("@AlarmGroupName", newTagObject.AlarmGroup));
                    command.Parameters.Add(new SqlParameter("@OtdName", newTagObject.Otd));
                    command.Parameters.Add(new SqlParameter("@AcknowledgeAllowedLocation", newTagObject.AcknowledgeAllowed));
                    command.Parameters.Add(new SqlParameter("@AlwaysVisibleLocation", newTagObject.AlwaysVisible));
                    command.Parameters.Add(new SqlParameter("@NodeName", newTagObject.Node));
                    command.Parameters.Add(new SqlParameter("@CabinetName", newTagObject.Cabinet));
                    command.Parameters.Add(new SqlParameter("@DataBlockName", newTagObject.DataBlock));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when inserting data into database: " + ex.Message);
                }
            }
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
                            tagObject.ObjectDescription = dataReader["ObjectDescription"].ToString();
                            tagObject.Hierarchy_1 = dataReader["Hierarchy1Name"].ToString();
                            tagObject.Hierarchy_2 = dataReader["Hierarchy2Name"].ToString();
                            tagObject.VduGroup = dataReader["VduGroupName"].ToString();
                            tagObject.AlarmGroup = dataReader["AlarmGroupName"].ToString();
                            tagObject.Otd = dataReader["OtdName"].ToString();
                            tagObject.AcknowledgeAllowed = dataReader["AcknowledgeAllowedLocation"].ToString();
                            tagObject.AlwaysVisible = dataReader["AlwaysVisibleLocation"].ToString();
                            tagObject.Node = dataReader["NodeName"].ToString();
                            tagObject.Cabinet = dataReader["CabinetName"].ToString();
                            tagObject.DataBlock = dataReader["DataBlockName"].ToString();
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when retrieving data from database" + ex.Message);
                }
            }
            return tagObject;
        }

        public void EditTagObject(TagObject updatedTagObject)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UpdateObject", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ObjectId", updatedTagObject.Id));
                    command.Parameters.Add(new SqlParameter("@SfiNumber", updatedTagObject.SfiNumber));
                    command.Parameters.Add(new SqlParameter("@MainEqNumber", updatedTagObject.MainEqNumber));
                    command.Parameters.Add(new SqlParameter("@EqNumber", updatedTagObject.EqNumber));
                    command.Parameters.Add(new SqlParameter("@ObjectDescription", updatedTagObject.ObjectDescription));
                    command.Parameters.Add(new SqlParameter("@Hierarchy1Name", updatedTagObject.Hierarchy_1));
                    command.Parameters.Add(new SqlParameter("@Hierarchy2Name", updatedTagObject.Hierarchy_2));
                    command.Parameters.Add(new SqlParameter("@VduGroupName", updatedTagObject.VduGroup));
                    command.Parameters.Add(new SqlParameter("@AlarmGroupName", updatedTagObject.AlarmGroup));
                    command.Parameters.Add(new SqlParameter("@OtdName", updatedTagObject.Otd));
                    command.Parameters.Add(new SqlParameter("@AcknowledgeAllowedLocation", updatedTagObject.AcknowledgeAllowed));
                    command.Parameters.Add(new SqlParameter("@AlwaysVisibleLocation", updatedTagObject.AlwaysVisible));
                    command.Parameters.Add(new SqlParameter("@NodeName", updatedTagObject.Node));
                    command.Parameters.Add(new SqlParameter("@CabinetName", updatedTagObject.Cabinet));
                    command.Parameters.Add(new SqlParameter("@DataBlockName", updatedTagObject.DataBlock));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when inserting data into database: " + ex.Message);
                }
            }
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error when inserting data into database" + ex.Message);
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

                    command.Parameters.Add(new SqlParameter("@ObjectId", tagObject.Id));
                    command.Parameters.Add(new SqlParameter("@SfiNumber", tagObject.SfiNumber));
                    command.Parameters.Add(new SqlParameter("@MainEqNumber", tagObject.MainEqNumber));
                    command.Parameters.Add(new SqlParameter("@EqNumber", tagObject.EqNumber));
                    command.Parameters.Add(new SqlParameter("@ObjectDescription", tagObject.ObjectDescription));
                    command.Parameters.Add(new SqlParameter("@Hierarchy1Name", tagObject.Hierarchy_1));
                    command.Parameters.Add(new SqlParameter("@Hierarchy2Name", tagObject.Hierarchy_2));
                    command.Parameters.Add(new SqlParameter("@VduGroupName", tagObject.VduGroup));
                    command.Parameters.Add(new SqlParameter("@AlarmGroupName", tagObject.AlarmGroup));
                    command.Parameters.Add(new SqlParameter("@OtdName", tagObject.Otd));
                    command.Parameters.Add(new SqlParameter("@AcknowledgeAllowedLocation", tagObject.AcknowledgeAllowed));
                    command.Parameters.Add(new SqlParameter("@AlwaysVisibleLocation", tagObject.AlwaysVisible));
                    command.Parameters.Add(new SqlParameter("@NodeName", tagObject.Node));
                    command.Parameters.Add(new SqlParameter("@CabinetName", tagObject.Cabinet));
                    command.Parameters.Add(new SqlParameter("@DataBlockName", tagObject.DataBlock));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when inserting data into database: " + ex.Message);
                }
            }
        }
    }
}
