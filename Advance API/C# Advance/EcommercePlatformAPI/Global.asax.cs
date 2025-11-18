using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using System.Web.Http;

namespace EcommercePlatformAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Database connection using connection string and orm lite tool
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);

            //Storing OrmLiteConnectionFactory instance for further usage in any other component.
            Application["DbFactory"] = dbFactory;
        }
    }
}
