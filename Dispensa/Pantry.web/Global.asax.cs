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
        public string SelectedActualUser
        {
            get { return (string)Session["ActualUser"]; }
            set { Session["ActualUser"] = value; }
        }
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Global variables
         
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["ActualUser"] = null;
        }
    }
}