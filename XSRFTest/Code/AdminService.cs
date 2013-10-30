using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XSRFTest.Code
{
    public class AdminService
    {
        private static AdminService _current;
        public static AdminService Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new AdminService();
                }
                return _current;
            }
        }

        private AdminService()
        {
        }

        public IList<string> GetAdmins()
        {
            var admins = HttpContext.Current.Cache["Admins"] as IList<string>;
            if (admins == null)
            {
                HttpContext.Current.Cache["Admins"] = new List<string>{
                    "graybealmi"
                };
                admins = HttpContext.Current.Cache["Admins"] as IList<string>;
            }
            return admins;
        }

        public bool IsAdmin(string name)
        {
            return GetAdmins().Contains(name);
        }

        public void AddAdmin(string name)
        {
            var admins = GetAdmins();
            admins.Add(name);
            HttpContext.Current.Cache["Admins"] = admins.Distinct().ToList();
        }

    }
}