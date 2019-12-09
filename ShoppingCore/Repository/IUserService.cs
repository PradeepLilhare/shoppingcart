using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
   public interface IUserService 
    {
        object UserSignUp(UserModel _userRequest);

        object UpdateUser(UserModel _userRequest);

        object GetUserList();

        object GetUserById(int intUserId);      
    }
}
