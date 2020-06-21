using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper;
using System.Web.Script.Serialization;

namespace TestWebSite.Handlers
{
    /// <summary>
    /// Summary description for DBSqlTypes
    /// </summary>
    public class DBSqlTypes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            List<string> types = DBHelper.GetTablesNameFromDB.GetDatabaseList();
            context.Response.ContentType = "application/json";
            context.Response.Write(new JavaScriptSerializer().Serialize(types));
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