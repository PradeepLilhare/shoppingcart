using ShoppingWebModule.CommonClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string cookieName = "";// "UserDDLPrefCookie" + ((ApiUser)filterContext.HttpContext.Session["apiUser"]).UserName.ToString();
            string SelectedBUID = "0", SelectedClinicID = "0";
            //Remove Location from left menu bar on 26 dec 2017
            // string SelectedBUID = "0", SelectedClinicID = "0", SelectedSupplyLocationID = "0";

            HttpCookie UserDDLPrefCookie = filterContext.HttpContext.Request.Cookies[cookieName];
            if (UserDDLPrefCookie != null)
            {
                if (!String.IsNullOrEmpty(UserDDLPrefCookie.Values["SelectedBUID"]))
                {
                    SelectedBUID = UserDDLPrefCookie.Values["SelectedBUID"].ToString();
                }
                if (!String.IsNullOrEmpty(UserDDLPrefCookie.Values["SelectedClinicID"]))
                {
                    SelectedClinicID = UserDDLPrefCookie.Values["SelectedClinicID"].ToString();
                }
                //Remove Location from left menu bar on 26 dec 2017
                //if (!String.IsNullOrEmpty(UserDDLPrefCookie.Values["SelectedSupplyLocationID"]))
                //{
                //    SelectedSupplyLocationID = UserDDLPrefCookie.Values["SelectedSupplyLocationID"].ToString();
                //}

                int intBUID = Convert.ToInt32(SelectedBUID);
                int intClinicID = Convert.ToInt32(SelectedClinicID);
                // Remove Location from left menu bar on 26 dec 2017
                // int intSupplyLocationID = Convert.ToInt32(SelectedSupplyLocationID);


                filterContext.HttpContext.Session["SelectedBUID"] = intBUID;
                if (intBUID != 0)
                {
                    ////List<Capsure.Core.Models.PatientManagement.Clinic> Clinics = new List<Capsure.Core.Models.PatientManagement.Clinic>();
                    //Clinics.Add(new Capsure.Core.Models.PatientManagement.Clinic { ClinicId = 0, ClinicName = "Select" });

                    //var listClinics = ((ApiUser)filterContext.HttpContext.Session["apiUser"]).Clinics.Where(i => i.BusinessUnitId == intBUID).OrderBy(e => e.ClinicName);
                    //Clinics.AddRange(listClinics);

                    ////var Clinics = ((ApiUser)filterContext.HttpContext.Session["apiUser"]).Clinics.Where(i => i.BusinessUnitId == intBUID).OrderBy(e => e.ClinicName);
                    //filterContext.HttpContext.Session["Clinics"] = Clinics;
                    //filterContext.HttpContext.Session["SelectedClinicID"] = intClinicID;
                }
                else
                {
                    filterContext.HttpContext.Session["Clinics"] = null;
                    filterContext.HttpContext.Session["SelectedClinicID"] = 0;
                }

                if (intClinicID != 0)
                {
                    //List<SupplyLocation> Locations = new List<SupplyLocation>();
                    //Locations.Add(new SupplyLocation { SupplyLocationId = 0, LocationName = "Select" });

                    //int OrganizationID = Convert.ToInt32(((ApiUser)filterContext.HttpContext.Session["apiUser"]).Clinics.Where(i => i.ClinicId == intClinicID).First().OrganizationId);
                    //var listLocations = ((ApiUser)filterContext.HttpContext.Session["apiUser"]).SupplyLocations.Where(i => i.OrganizationId == OrganizationID).OrderBy(e => e.LocationName);
                    //Locations.AddRange(listLocations);
                    // Remove Location from left menu bar on 26 dec 2017
                    // filterContext.HttpContext.Session["Locations"] = Locations;
                    // filterContext.HttpContext.Session["SelectedSupplyLocationID"] = intSupplyLocationID;
                    // filterContext.HttpContext.Session["DepartmentID"] = Locations.Where(s => s.SupplyLocationId == intSupplyLocationID).Select(d => d.DepartmentId).Single();
                }
                else
                {
                    //  Remove Location from left menu bar on 26 dec 2017
                    // filterContext.HttpContext.Session["Locations"] = null;
                    // filterContext.HttpContext.Session["SelectedSupplyLocationID"] = 0;
                }
            }
            else
            {
                //HttpCookie UserDDLPrefCookieToSet = new HttpCookie("UserDDLPrefCookie");
                //UserDDLPrefCookieToSet.Values.Add("SelectedBUID", "2");
                //UserDDLPrefCookieToSet.Expires = DateTime.MaxValue;
                //Response.Cookies.Add(UserDDLPrefCookieToSet);

            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage2 = "Custom Action Filter: Message from OnActionExecuted method.";
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage3 = "Custom Action Filter: Message from OnResultExecuting method.";
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage4 = "Custom Action Filter: Message from OnResultExecuted method.";
        }
    }
    public class CheckapiUserSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["apiUser"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            else
            {
                // Remove Location from left menu bar on 26 dec 2017
                // if (HttpContext.Current.Session["SelectedBUID"] == null || HttpContext.Current.Session["SelectedClinicID"] == null || HttpContext.Current.Session["SelectedSupplyLocationID"] == null)
                if (HttpContext.Current.Session["SelectedBUID"] == null || HttpContext.Current.Session["SelectedClinicID"] == null)

                {
                    filterContext.Result = new RedirectResult("~/DashBoard/Index");
                    return;
                }
                // Remove Location from left menu bar on 26 dec 2017
                //if (HttpContext.Current.Session["SelectedBUID"].ToString() == "0" || HttpContext.Current.Session["SelectedClinicID"].ToString() == "0" || HttpContext.Current.Session["SelectedSupplyLocationID"].ToString() == "0")
                if (HttpContext.Current.Session["SelectedBUID"].ToString() == "0" || HttpContext.Current.Session["SelectedClinicID"].ToString() == "0")
                {
                    filterContext.Result = new RedirectResult("~/DashBoard/Index");
                    return;
                }

                #region Block Url 
                var descriptor = filterContext.ActionDescriptor;
                var ControllerName = descriptor.ControllerDescriptor.ControllerName;
                var ActionName = descriptor.ActionName;
                if (ClsCommon.BlockUrl(ControllerName, ActionName) == false)
                {
                    filterContext.Result = new RedirectResult("~/DashBoard/Index");
                    return;
                }
                #endregion
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            LogError(filterContext);
            // base.OnException(filterContext);

            filterContext.Result = new RedirectResult("~/ErrorPage/Index");
            filterContext.ExceptionHandled = true;
        }

        //public override void OnException(ExceptionContext filterContext)
        //{
        //    LogError(filterContext);
        //    base.OnException(filterContext);
        //}

        public void LogError(ExceptionContext filterContext)
        {

            StringBuilder builder = new StringBuilder();
            builder
                .AppendLine("----------")
                .AppendLine(DateTime.Now.ToString())
                .AppendFormat("Source:\t{0}", filterContext.Exception.Source)
                .AppendLine()
                .AppendFormat("Target:\t{0}", filterContext.Exception.TargetSite)
                .AppendLine()
                .AppendFormat("Type:\t{0}", filterContext.Exception.GetType().Name)
                .AppendLine()
                .AppendFormat("Message:\t{0}", filterContext.Exception.Message)
                .AppendLine()
                .AppendFormat("Stack:\t{0}", filterContext.Exception.StackTrace)
                .AppendLine();

            string filePath = filterContext.HttpContext.Server.MapPath("~/ErrorLog/Error.log");

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(builder.ToString());
                writer.Flush();
            }

        }
    }
}