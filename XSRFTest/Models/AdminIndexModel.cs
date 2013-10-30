using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XSRFTest.Models
{
    public class AdminIndexModel
    {
        public IList<string> Admins { get; set; }
    }
}