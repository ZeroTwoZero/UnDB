using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DBHelper
{
    public static class SQLServerDetails
    {
        public static SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();

        public static SqlConnection SQLConnection;

        public static SqlConnection GetConnectionString(string sName, string sDBName, string sUName = null, string sPwd = null) {
            if (!string.IsNullOrEmpty(sql.ConnectionString) && sql.DataSource.Equals(sName) && sql.InitialCatalog.Equals(sDBName)
                && ((string.IsNullOrEmpty(sUName) && string.IsNullOrEmpty(sPwd) && string.IsNullOrEmpty(sql.UserID) && string.IsNullOrEmpty(sql.Password))
                || (!string.IsNullOrEmpty(sUName) && !string.IsNullOrEmpty(sPwd) && !string.IsNullOrEmpty(sql.UserID) && !string.IsNullOrEmpty(sql.Password)
                    && sUName.Equals(sql.UserID) && sPwd.Equals(sql.Password))))
            {
                return SQLConnection;
            }
            else {
                sql.IntegratedSecurity = true;
                sql.DataSource = sName;
                sql.InitialCatalog = sDBName;
                sql.ConnectTimeout = 1;
                if (!string.IsNullOrEmpty(sUName) && !string.IsNullOrEmpty(sPwd))
                {
                    sql.IntegratedSecurity = false;
                    sql.UserID = sUName;
                    sql.Password = sPwd;
                }
                SQLConnection = new SqlConnection(sql.ConnectionString);
                return SQLConnection;
            }  
        }
    }
}
