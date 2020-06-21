using System;
using System.Data.SqlClient;
using DBHelper;

namespace DBHelper
{
    public class CheckServerConnection
    {
        public bool CheckDBServerConnection(string serverName, string dbName, string serverUName = null, string serverPwd = null)
        {
            bool isConnected = false;
            if (string.IsNullOrEmpty(serverUName) && string.IsNullOrEmpty(serverPwd)) {
                SqlConnection connect = null;
                try
                {
                    connect = SQLServerDetails.GetConnectionString(serverName, dbName);
                    connect.Open();
                    isConnected = true;

                }
                catch (Exception e)
                {
                    isConnected = false;

                }
                finally
                {
                    if (connect != null)
                        connect.Close();
                }
            }
            return isConnected;
        }
    }
}
