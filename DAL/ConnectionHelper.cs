using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SP2FUN.DAL
{

    class GetConnectionString {

        private static string dbStatus = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public static string DbStatus
        {
            get { return dbStatus; }
            set { dbStatus = value; }
        }
    }
 
    class ConnectionHelper
    {
        public static bool ShowDbStatus(string str) 
        {
            if (String.IsNullOrEmpty(str))
            {
                return  false;

            }
            else
            {
                return  true;
            }

        }

    }
}
