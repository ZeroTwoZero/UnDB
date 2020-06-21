using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using DBHelper;

namespace TestWebSite.Handlers
{
    /// <summary>
    /// Summary description for CreateTableInDB
    /// </summary>
    public class CreateTableInDB : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var data = context.Request;
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            var javaScriptSerializer = new JavaScriptSerializer();

            var tables = javaScriptSerializer.Deserialize<Tables>(stream);
            var isSuccessful = new SQLTableHelper().HandleTableDDLStatements(tables, DDLEnums.CreateTable);
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