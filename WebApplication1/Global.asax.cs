using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static string connectionString;
        protected void Application_Start()
        {
            // setup database connection string
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["somiodDB"].ConnectionString;
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
