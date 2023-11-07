using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace NOVOROV.DatabaseHelper
{
    public class Database
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection = null;

        public Database(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new SqlConnection(_configuration.GetConnectionString("NovoRovConnection"));
        }

        public Database(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool ExecuteQuery(string query)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                var result = cmd.ExecuteNonQuery();

                connection.Close();
                cmd.Dispose();
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                connection.Close();
                return false;
            }
        }

        public SqlCommand GetCommand(string query)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                return cmd;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                connection.Close();
                return null;
            }
        }
    }
}

