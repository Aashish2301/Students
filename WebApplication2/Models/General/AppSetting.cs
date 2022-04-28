using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebApplication2.Models.Account;

namespace WebApplication2.Models.General
{
    public class AppSetting
    {

        public static string  ConnectionStrings()
        {
            return ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
        
        }

    }
}