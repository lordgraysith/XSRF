using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Web;

namespace XSRFTest.Code
{
    public class XSRFTokenGenerator : Lds.CES.XSRF.IXSRFTokenGenerator
    {
        public string GetRequestToken()
        {
            if (HttpContext.Current.Session["XSRF-TOKEN"] as string == null)
            {
                HttpContext.Current.Session["XSRF-TOKEN"] = GenerateRequestToken();
            }
            return HttpContext.Current.Session["XSRF-TOKEN"] as string;
        }

        private string GenerateRequestToken()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] data = new byte[32];
            random.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public void ValidateToken(string tokenIn)
        {
            if (!String.Equals(tokenIn, GetRequestToken()))
            {
                throw new SecurityException();
            }
        }
    }
}