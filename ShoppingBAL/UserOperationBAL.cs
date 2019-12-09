using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
   public class UserOperationBAL
    {
        UserOperationDataAccess  _dataaccess = new UserOperationDataAccess();

        public List<UserModel> UserMastersList(List<UserModel> _listProduct)
        {
            return _dataaccess.UserMastersList(_listProduct);
        }
        public UserModel SaveUser(UserModel _objproduct)
        {
            return _dataaccess.SaveUser(_objproduct);
        }
        public UserModel UpdateUser(UserModel _objproduct)
        {
            return _dataaccess.UpdateUser(_objproduct);
        }
        public List<CountryList> GetCountryList()
        {
            return _dataaccess.GetCountryList();
        }
        public List<StateList> GetStateList()
        {
            return _dataaccess.GetStateList();
        }
        public List<CityList> GetCityList()
        {
            return _dataaccess.GetCityList();
        }

        public List<UserTypeList> GetUserTypeList()
        {
            return _dataaccess.GetUserTypeList();
        }

        public UserModel GetUserListById(UserModel _productmodal)
        {
            return _dataaccess.GetUserById(_productmodal);
        }
    }
}
