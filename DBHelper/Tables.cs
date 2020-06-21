using System;

namespace DBHelper
{
    [Serializable]
    public class Tables
    {
        public string TableName { get; set; }
        public string[] ColumnNames { get; set; }
        public string[] ColumnTypes { get; set; }
    }
}
