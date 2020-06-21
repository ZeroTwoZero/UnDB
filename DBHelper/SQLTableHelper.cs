using DBHelper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DBHelper
{
    public class SQLTableHelper
    {
        private SqlConnection _sqlConnection;

        public bool HandleTableDDLStatements(Tables table, DDLEnums ddlEnum)
        {
            bool isSuccessful = false;
            try
            {
                _sqlConnection = SQLServerDetails.SQLConnection;
                string columns = null;
                switch (ddlEnum)
                {
                    case DDLEnums.CreateTable:
                        columns = "Create table " + table.TableName + "(";
                        for (int i = 0; i < table.ColumnNames.Count(); i++)
                        {
                            columns += table.ColumnNames[i] + " " + table.ColumnTypes[i];
                            if (i + 1 != table.ColumnNames.Count())
                                columns = columns + ",\n";
                        }
                        columns = columns + ")";
                        break;
                    case DDLEnums.AlterTable:
                        columns = "Alter table " + table.TableName + "(";
                        for (int i = 0; i < table.ColumnNames.Count(); i++)
                        {
                            columns += table.ColumnNames[i] + " " + table.ColumnTypes[i];
                            if (i + 1 != table.ColumnNames.Count())
                                columns = columns + ",\n";
                        }
                        columns = columns + ")";
                        break;
                    case DDLEnums.DeleteTable:
                        columns = "Drop table " + table.TableName;
                        break;
                    default:break;
                }
                SqlCommand sqlCmnd = new SqlCommand(columns, _sqlConnection);
                _sqlConnection.Open();
                sqlCmnd.ExecuteNonQuery();
                isSuccessful = true;
            }
            catch (Exception e)
            {
                isSuccessful = false;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return isSuccessful;
        }
    }
}
