using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeAuthenticationProcess();
        }
        private void InitializeAuthenticationProcess()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("dbx", "Users", "UserId", "UserName", true);
                //WebSecurity.CreateUserAndAccount("admin", "admin33");
                //Roles.CreateRole("Administrator");
                //Roles.CreateRole("Manager");
                //Roles.CreateRole("User");

                //Roles.AddUserToRole("admin", "Administrator");
                //Roles.AddUserToRole("admin", "Manager");
                //Roles.AddUserToRole("admin", "User");

            }
        }
    }
}
