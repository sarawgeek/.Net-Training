using System.Data.SqlClient;

namespace EComADO.AL
{
    public class SQLUtil
    {

        IConfiguration _config;
        public SQLUtil(IConfiguration config)
        {
            this._config = config;
        }


        public SqlConnection getConnection()
        {
            string constr = _config.GetConnectionString("localserver").ToString();
            SqlConnection sqlConnection = new SqlConnection(constr);
            sqlConnection.Open();
            return sqlConnection;
        }

        public SqlCommand getCommand(string sql, SqlConnection con)
        {
            SqlCommand command = new SqlCommand(sql, con);
            return command;
        }

        public SqlDataReader getReader(string sql)
        {
            SqlDataReader reader = getCommand(sql, getConnection()).ExecuteReader();
            return reader;
        }


    }
}




/*
 * ARCHITECTURES OF ADO.NET
 * -----------------------------
 * 1. CONNECTED ARCHITECTURE
 *      - CONNECTION IS ALWAYS CONNECTED
 *      - DataReader    
 * 2. DISCONNECTED ARCHITECTURE
 *      - CONNECTION IS DISCONNECTED BY ADO.NET
 *      - DataSet
 *  
 * 
 * */