using DBHelper;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace TestWebSite.Handlers
{
    /// <summary>
    /// Summary description for GetTableNamesFromDB
    /// </summary>
    public class GetTableNamesFromDB : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            List<string> types = GetTablesNameFromDB.GetDatabaseList();
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