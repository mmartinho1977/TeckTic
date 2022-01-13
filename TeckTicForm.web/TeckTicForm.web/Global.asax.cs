using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TeckTicForm.web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["Images"] = (string)System.Configuration.ConfigurationManager.AppSettings["Images"];
            Application["MessagePage"] = (string)System.Configuration.ConfigurationManager.AppSettings["MessagePage"];
            Application["DefaultPage"] = (string)System.Configuration.ConfigurationManager.AppSettings["DefaultPage"];
            Application["Email"] = (string)System.Configuration.ConfigurationManager.AppSettings["Email"];
            Application["Password"] = (string)System.Configuration.ConfigurationManager.AppSettings["Password"];
            Application["SMTP"] = (string)System.Configuration.ConfigurationManager.AppSettings["SMTP"];
        }
    }
}