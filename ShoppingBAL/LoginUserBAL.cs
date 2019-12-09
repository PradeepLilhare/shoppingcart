using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
   public class LoginUserBAL
    {
        public UserModel LoginUser(LoginViewModel _objLogin)
        {
            try
            {
                UserModel _login = new UserModel();
                LoginUserDataAccess _objdataAccess = new LoginUserDataAccess();
                _login = _objdataAccess.CheckLogin(_objLogin);
               
                return _login;
            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                throw ex;
            }
        }
    }
}
