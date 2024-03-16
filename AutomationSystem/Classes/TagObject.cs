using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace AutomationSystem.Classes
{
    class TagObject
    {
        public void SaveData(string  objectName, string objectType)
        {
            string connectionString = DatabaseAccess.GetConnectionString();

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
    }
}
