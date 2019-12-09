using ShoppingDataAccess;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
    public class LoginService : ILoginService
    {
        private newconecommerce dataContext = DBDatacontext.DataContext;

        //public object CheckLogin(UserModel _login)
        //{
        //    tbl_All_User log = new tbl_All_User();
        //    try
        //    {
        //        using (newconecommerce dataContext = new newconecommerce())
        //        {
        //            dataContext.Database.Connection.Open();
        //            var query = dataContext.tbl_All_User.Where(a => a.v_EmailId == _login.strEmailId || a.v_MobileNo == _login.strEmailId && a.v_Password == _login.strPassword).FirstOrDefault();

        //            var querye = dataContext.tbl_All_User.Where(a => a.v_EmailId == _login.strEmailId || a.v_MobileNo == _login.strMobileNo).FirstOrDefault();
        //            var _checkAlreadyLogin = (object)null;
        //            if (query!=null)
        //             _checkAlreadyLogin = (from x in dataContext.tbl_OTP
        //                                      where x.int_user_id == query.int_id && x.dt_logout_time == null
        //                                      select x.int_user_id).FirstOrDefault();

        //            if (querye != null)
        //            {
        //                if (query == null)
        //                {
        //                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.UnAuthorizedAccess, StatusMessaage = "Email id and password do not match.", data = log };
        //                }
        //                else if (_checkAlreadyLogin != null)
        //                {
        //                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = CCommon.StatusCode.Fail.ToString(), data = "Already logged in with other device." };
        //                }
        //                else
        //                {
        //                    Random generator = new Random();
        //                    string number = generator.Next(1, 10000).ToString("D4");
        //                    string strMessage = "Your OTP for Just Cool App is :" + number + ". Regards Just Cool.com";

        //                    tbl_OTP _objLoginInput = new tbl_OTP();
        //                    _objLoginInput.int_moduleType_id = _login.intModuleTypeId;
        //                    _objLoginInput.int_user_id = _login.int_id;
        //                    _objLoginInput.int_OTP = Convert.ToInt32(number);
        //                    _objLoginInput.dt_OTP_created = DateTime.Now;
        //                    _objLoginInput.dt_login_time = DateTime.Now;
        //                    _objLoginInput.v_device_id = _login.strDeviceId;
        //                    _objLoginInput.v_device_token = _login.strDevicetoken;
        //                    _objLoginInput.v_device_token = _login.strDevicemode;
        //                    _objLoginInput.dt_created_on = DateTime.Now;
        //                    dataContext.tbl_OTP.Add(_objLoginInput);
        //                    dataContext.SaveChanges();
        //                    dataContext.Database.Connection.Close();
        //                }
        //                log = query;
        //                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = log };
        //            }
        //            else
        //            {
        //                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.InvalidMailId, StatusMessaage = "Could not find email id in our system.", data = log };
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
        //        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = log };
        //    }
        //}
        public object CheckLogin(UserModel _login)
        {
            try
            {
                Postloginres _log = new Postloginres();
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var command = dataContext.Database.Connection.CreateCommand();
                    command.CommandText = "usp_user_login";
                    command.CommandType = CommandType.StoredProcedure;
                    var p = new SqlParameter("@v_EmailId", _login.strEmailId);
                    var p1 = new SqlParameter("@v_Password", _login.strPassword);
                    var p2 = new SqlParameter("@v_MobileNo", _login.strMobileNo);
                    var p3 = new SqlParameter("@intModuleTypeId", _login.intModuleTypeId);
                    var p4 = new SqlParameter("@strDeviceId", _login.strDeviceId);
                    var p5 = new SqlParameter("@strDevicetoken", _login.strDevicetoken);
                    var p6 = new SqlParameter("@strDevicemode", _login.strDevicemode);
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);
                    command.Parameters.Add(p5);
                    command.Parameters.Add(p6);
                    var reader = command.ExecuteReader();
                    DataSet oDS = new DataSet();
                    while (!reader.IsClosed)
                        oDS.Tables.Add().Load(reader);


                    if (oDS.Tables[0].Rows.Count != 0)
                    {
                        _log.intUserId = Convert.ToInt32(oDS.Tables[0].Rows[0]["int_id"]);
                        _log.strName = oDS.Tables[0].Rows[0]["strName"].ToString();
                        _log.strEmailId = oDS.Tables[0].Rows[0]["strEmailId"].ToString();
                        _log.strMobileNo = oDS.Tables[0].Rows[0]["strMobileNo"].ToString();
                        _log.strMsg = oDS.Tables[0].Rows[0]["Msg"].ToString();
                        dataContext.Database.Connection.Close();
                    }
                    dataContext.Database.Connection.Close();
                }

                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _log };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public object PostLogin(Postloginreq _login)
        {
            try
            {
                Random generator = new Random();
                string number = generator.Next(1, 10000).ToString("D4");
                string strMessage = "Your OTP for Just Cool App is :" + number + ". Regards Corvi.com";

                using (newconecommerce dataContext = new newconecommerce())
                {
                    var query = (from x in dataContext.tbl_OTP
                                 where x.int_user_id == _login.intloginId && x.dt_logout_time == null
                                 select x.int_user_id).FirstOrDefault();

                    if (query != null)
                    {
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = CCommon.StatusCode.Fail.ToString(), data = "Already logged in with other device." };
                    }
                    else
                    {
                        dataContext.Database.Connection.Open();

                        tbl_OTP _objLoginInput = new tbl_OTP();
                        _objLoginInput.int_moduleType_id = _login.intModuleTypeId;
                        _objLoginInput.int_user_id = _login.intloginId;
                        _objLoginInput.int_OTP = Convert.ToInt32(number);
                        _objLoginInput.dt_OTP_created = DateTime.Now;
                        _objLoginInput.dt_login_time = DateTime.Now;
                        _objLoginInput.v_device_id = _login.strDeviceId;
                        _objLoginInput.v_device_token = _login.strDevicetoken;
                        _objLoginInput.v_device_token = _login.strDevicemode;
                        _objLoginInput.dt_created_on = DateTime.Now;
                        dataContext.tbl_OTP.Add(_objLoginInput);
                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();

                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = "Login success" };
                    }
                }
            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = "Failed to login." };
            }
        }

        public object PostLogout(Postloginreq _login)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();

                    tbl_OTP _logoutInput = dataContext.tbl_OTP.Single(e => e.int_user_id == _login.intloginId && e.dt_logout_time == null);
                    _logoutInput.dt_logout_time = DateTime.Now;
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();

                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = "" };
                }
            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = "" };
            }
        }

        public object ChangePassword(int UserId, string ChangePassword, int int_moduleType_id, string OldPassword)
        {
            try
            {
                var _userPswd = dataContext.tbl_All_User.Where(a => a.int_id == UserId && a.int_User_Type == int_moduleType_id).FirstOrDefault();

                if (_userPswd != null)
                {
                    if (_userPswd.v_Password != OldPassword)
                    {
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = CCommon.StatusCode.Fail.ToString(), data = "Incorrect Old Password." };
                    }
                    else
                    {
                        _userPswd.v_Password = ChangePassword;
                    }
                }
                int Result = dataContext.SaveChanges();
                return new ResponseModel { StatusCode = Result != 0 ? (int)CCommon.StatusCode.Success : (int)CCommon.StatusCode.Notsaved, StatusMessaage = Result != 0 ? CCommon.StatusCode.Success.ToString() : CCommon.StatusCode.Notsaved.ToString(), data = "" };

            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = "" };
            }
        }

        public object ForgotPassword(string email_id)
        {
            try
            {
                int isMailsend = 0;
                var res = dataContext.tbl_All_User.Where(a => a.v_EmailId == email_id).FirstOrDefault();
                if (res != null)
                {
                    isMailsend = sentForgetPasswordEmail(res.v_EmailId, res.v_Password);
                    return new ResponseModel { StatusCode = isMailsend != 1 ? (int)CCommon.StatusCode.Fail : (int)CCommon.StatusCode.Success, StatusMessaage = isMailsend != 1 ? "Could not find email id in our system." : "Please check your email. The password has been sent there.", data = "" };
                }
                else
                {
                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = "Could not find email id in our system.", data = "" };
                }
            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = "" };
            }

        }

        private int sentForgetPasswordEmail(string email_id, string password)
        {
            return CMail.SendSystemGeneratedMail(email_id,
                  "Password Retrieved",
                  "Dear User, Your login details are. Your Username is : " + email_id + " and Password is : " + password + "<br/><br/>Thank you,<br/>Just Cool",
                  ConfigurationManager.AppSettings["display_name"], true);
        }
    }
}
