using System.Data.SqlClient;

namespace HumanitarianProjectManagement.DataAccessLayer
{
    public static class DatabaseHelper
    {
        // TODO: This connection string should be moved to a configuration file (e.g., App.config or appsettings.json).
        private static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=HumanitarianProjectsDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
