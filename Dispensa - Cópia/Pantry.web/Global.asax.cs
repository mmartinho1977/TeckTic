using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Pantry.web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string connectionString;

            //core
            connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString().TrimEnd();


            //Global variables
            Application["ConnectionString"] = connectionString;
        }
    }
}