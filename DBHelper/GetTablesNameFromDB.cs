using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;

namespace DBHelper
{
    public static class GetTablesNameFromDB
    {
        public static List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();
            SqlConnection con = null;
            try
            {
                con = SQLServerDetails.SQLConnection;
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                { //List<string> tables = new List<string>();  
                    DataTable dt = con.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tablename = (string)row[1] + "." + (string)row[2];
                        list.Add(tablename);
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                con?.Close();
            }
            return list;
        }
    }
}
