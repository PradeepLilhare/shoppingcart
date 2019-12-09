using ShoppingDataAccess;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class LoginUserDataAccess
    {
        private newconecommerce dataContext = DBDatacontext.DataContext;

        public UserModel CheckLogin(LoginViewModel _login)
        {
            try
            {
                UserModel _log = new UserModel();              
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                   
                    var command = dataContext.Database.Connection.CreateCommand();
                    command.CommandText = "[usp_user_login]";
                    command.CommandType = CommandType.StoredProcedure;
                    var p = new SqlParameter("@v_EmailId", _login.strEmailId);
                    var p1 = new SqlParameter("@v_Password", _login.strPassword);
                    //var p2 = new SqlParameter("@v_MobileNo", _login.strMobileNo);
                    //var p3 = new SqlParameter("@intModuleTypeId", _login.intModuleTypeId);
                    //var p4 = new SqlParameter("@strDeviceId", _login.strDeviceId);
                    //var p5 = new SqlParameter("@strDevicetoken", _login.strDevicetoken);
                    //var p6 = new SqlParameter("@strDevicemode", _login.strDevicemode);
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    //command.Parameters.Add(p2);
                    //command.Parameters.Add(p3);
                    //command.Parameters.Add(p4);
                    //command.Parameters.Add(p5);
                    //command.Parameters.Add(p6);
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
                        dataContext.Database.Connection.Close();
                    }
                    else
                        _log.StatusMessaage= oDS.Tables[0].Rows[0]["Msg"].ToString();
                }
                return _log;
                //return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _log };
            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);

                throw ex;
            }
        }
    }
}
