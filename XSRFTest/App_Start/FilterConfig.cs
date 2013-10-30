using System.Web;
using System.Web.Mvc;

namespace XSRFTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Lds.CES.XSRF.Mvc.RequestTokenValidatorAttribute());
        }
    }
}