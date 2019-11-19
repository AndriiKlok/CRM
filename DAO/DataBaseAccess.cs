using System;
using System.Data;
using System.Data.SqlClient;

namespace CRM_SYSTEM.DAO
{
    public class DataBaseAccess
    {
        public bool connected;

        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=CRM_DB;User ID=WEBUser;Password=2jhcYHebfbJYiCuK0sB4";
        private SqlCommand command;
        private SqlConnection connection;

        public DataBaseAccess()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connected = true;
                    connection.Close();

                    connection = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadProcedure(string ProcedureName)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                command = new SqlCommand(ProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameter(string name, dynamic value)
        {
            try
            {
                if (command == null) throw new Exception("LoadProcedue First");

                command.Parameters.Add(new SqlParameter(name, value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteProcedure()
        {
            try
            {
                DataTable dt = new DataTable();

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
                connection.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
