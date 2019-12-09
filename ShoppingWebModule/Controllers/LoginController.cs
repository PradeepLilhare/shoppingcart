using ShoppingBAL;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    [CustomActionFilter]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Session["strUserName"] == null)
            {
                ViewBag.UserAuthenticated = false;
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }

            else
                return RedirectToAction("LoginSuccess", "DashBoard");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                UserModel _objlogindetails = new UserModel();
                LoginUserBAL _loginbal = new  LoginUserBAL();
                _objlogindetails = _loginbal.LoginUser(model);
                if(_objlogindetails.StatusMessaage!=null)
                {
                    ModelState.AddModelError("",_objlogindetails.StatusMessaage);
                    return View(model);
                }
                Session["strUserId"] = _objlogindetails.int_id;
                Session["strUserName"] = _objlogindetails.strName;               
                Session["strEmailId"] = _objlogindetails.strEmailId;
                Session["strMobileNo"] = _objlogindetails.strMobileNo;

                return RedirectToAction("Index", "DashBoard");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("That's not a valid username or password."))
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
                else
                {
                    CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                    throw ex;
                }

            }

        }
    }
}