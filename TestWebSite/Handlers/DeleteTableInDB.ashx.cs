using DBHelper;
using System.Web;
using System.Web.UI.WebControls;

namespace TestWebSite.Handlers
{
    /// <summary>
    /// Summary description for DeleteTableInDB
    /// </summary>
    public class DeleteTableInDB : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var tableName = context.Request.QueryString["tName"];
            Tables table = new Tables() { TableName = tableName };
            var isSuccessful = new SQLTableHelper().HandleTableDDLStatements(table, DDLEnums.DeleteTable);
            context.Response.Write(isSuccessful);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}