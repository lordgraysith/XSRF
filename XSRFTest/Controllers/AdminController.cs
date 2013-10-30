using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSRFTest.Code;
using XSRFTest.Filters;
using XSRFTest.Models;

namespace XSRFTest.Controllers
{
    [Admin]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            AdminIndexModel model = new AdminIndexModel
            {
                Admins = AdminService.Current.GetAdmins()
            };
            return View(model);
        }
        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                AdminService.Current.AddAdmin(collection["username"]);
                ViewBag.Message = "Success!";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Broken!";
                return View();
            }
        }
    }
}
