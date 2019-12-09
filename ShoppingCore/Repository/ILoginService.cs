using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
    public interface ILoginService 
    {
        object CheckLogin(UserModel _loginRequest);

        object PostLogin(Postloginreq _login);

        object PostLogout(Postloginreq _login);

        object ForgotPassword(string email_id);

        object ChangePassword(int UserId, string ChangePassword, int int_moduleType_id, string OldPassword);

    }
}
