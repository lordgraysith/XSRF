using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using XSRFTest.Code;

namespace XSRFTest.Filters
{
    public class AdminAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext actionExecutingContext)
        {
            string username = actionExecutingContext.RequestContext.HttpContext.Request.Headers["policy-cn"];
            AdminService adminService = AdminService.Current;
            if (!adminService.IsAdmin(username))
            {
                throw new HttpException(404, "not authorized");
            }
        }
    }
    [System.AttributeUsage(AttributeTargets.All)]
    public class Admin2Attribute : System.Attribute
    {
        public Admin2Attribute()
        {
            string username = HttpContext.Current.Request.Headers["policy-cn"];
            AdminService adminService = AdminService.Current;
            if (!adminService.IsAdmin(username))
            {
                throw new HttpException(404, "not authorized");
            }
        }
    }
}
