using System;
using System.Data;

namespace DBHelper
{
    public static class GetSQLTypes
    {
        public static string[] GetSQLType()
        {
            string[] names = Array.ConvertAll((SqlDbType[])System.Enum.GetValues(typeof(SqlDbType)),
                             type => type.ToString());
            return names;
        }
    }
}
