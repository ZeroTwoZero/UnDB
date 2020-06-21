using DBHelper;
using System.Web;
using System.Web.Script.Serialization;

namespace TestWebSite.Handlers
{
    /// <summary>
    /// Summary description for DBConnectionChecker
    /// </summary>
    public class DBConnectionChecker : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var sName = context.Request.QueryString["sName"];
            var sDB = context.Request.QueryString["sDB"];
            var sUname = context.Request.QueryString["sUName"];
            var sPwd = context.Request.QueryString["serverPwd"];
            var winAuth = bool.Parse(context.Request.QueryString["winAuth"]);
            CheckServerConnection csc = new CheckServerConnection();
            //var isConnected = csc.CheckDBServerConnection(@".\sqlexpress", "Location_Tracker");
            bool isConnected = false;
            if (winAuth)
            {
                isConnected = csc.CheckDBServerConnection(sName, sDB);
            }
            else
            {
                isConnected= csc.CheckDBServerConnection(sName, sDB, sUname, sPwd);
            }
            JavaScriptSerializer j = new JavaScriptSerializer();
            context.Response.Write(isConnected);
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