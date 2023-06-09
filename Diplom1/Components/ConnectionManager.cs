using System.Configuration;
using MySql.Data.MySqlClient;

namespace Diplom1.Components
{
    public class ConnectionManager
    {

        private static MySqlConnection _connection;
        
        public static MySqlConnection GetConnection()
        {
            if (_connection != null) return _connection;
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            return _connection;
        }

        private static string ConnectionString
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; }
        }

        public static string strConnect
        {
            get
            { return System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString; }
        }

    }
}