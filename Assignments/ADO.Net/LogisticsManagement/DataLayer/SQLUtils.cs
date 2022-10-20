using System.Data.SqlClient;

namespace LogisticsManagement.DataLayer
{
    public class SQLUtils
    {
        // Configuration for this application
        IConfiguration _config;
        
        // SQL Connection
        SqlConnection _connection;
        public SQLUtils(IConfiguration config)
        {
            _config = config;
            _connection = new SqlConnection(_config.GetConnectionString("AWBServer"));
            _connection.Open();
        }

        /// <summary>
        /// Get SQL Command
        /// </summary>
        /// <param name="sql">SQL Command</param>
        /// <returns>return SQL Command</returns>
        public SqlCommand GetCommand(string sql)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, _connection);
            return sqlCmd;
        }

        /// <summary>
        /// Get SQL Reader
        /// </summary>
        /// <param name="sql">SQL Command</param>
        /// <returns>SQL Reader</returns>
        public SqlDataReader GetReader(string sql)
        {
            SqlDataReader reader = GetCommand(sql).ExecuteReader();
            return reader;
        }                

    }
}
