using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebModule.CommonClass
{
    public class ClsCommon
    {
        public static bool BlockUrl(string ControllerName, string ActionName)
        {
            //ApiUser apiUser = (ApiUser)HttpContext.Current.Session["apiUser"];
            //var IsAuthorized = false;
            //string Menu = GetControllerName(ControllerName, ActionName);
            //IsAuthorized = apiUser.MenuOptions.Where(m => m.MenuName == Menu).Select(auth => auth.IsAuthorized).FirstOrDefault();
            //return IsAuthorized;
            return true;
        }
    }
}