using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            if (Session["strUserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
       // [CustomActionFilters]
        public ActionResult LoginSuccess()
        {
            if (Session["strUserName"] != null)
            {
                return RedirectToAction("Index", "DashBoard");

            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}