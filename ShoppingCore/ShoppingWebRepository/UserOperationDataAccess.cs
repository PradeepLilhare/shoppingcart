using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class UserOperationDataAccess
    {
        public List<UserModel> UserMastersList(List<UserModel> _listuser)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<UserModel> _list = (from _user in dataContext.tbl_All_User
                                             join _state in dataContext.tbl_States on _user.int_StateId equals _state.int_Id
                                             join _city in dataContext.tbl_Cities on _user.int_CityId equals _city.int_Id
                                             join _country in dataContext.tbl_Countries on _user.int_CountryId equals _country.int_Id
                                             join _userType in dataContext.tbl_User_Types on _user.int_User_Type equals _userType.int_Id
                                             where _user.b_IsActive == true
                                             select new UserModel
                                             {
                                                 intModuleTypeId = (int)_user.int_User_Type,
                                                 strUserType=_userType.v_name,
                                                 strCity=_city.v_City,
                                                 intUserId=_user.int_id,
                                                 int_id = _user.int_id,
                                                 strFirstName = _user.v_FirstName,
                                                 strLastName = _user.v_LastName,
                                                 strEmailId = _user.v_EmailId,
                                                 strMobileNo = _user.v_MobileNo,
                                                 intCountryId = (int)_user.int_CountryId,
                                                 intCityId = (int)_user.int_CityId,
                                                 intStateId = (int)_user.int_StateId,
                                                 strAddress = _user.v_address,
                                                 strPassword = _user.v_Password
                                             }).ToList();
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserModel SaveUser(UserModel _objdata)
        {
            tbl_All_User _objuser = new tbl_All_User();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();

                    _objuser.int_id = (int)_objdata.int_id;
                    _objuser.int_User_Type = _objdata.intModuleTypeId;
                    _objuser.v_FirstName = _objdata.strFirstName;
                    _objuser.v_LastName = _objdata.strLastName;
                    _objuser.v_EmailId = _objdata.strEmailId;
                    _objuser.v_MobileNo = _objdata.strMobileNo;
                    _objuser.int_CountryId = _objdata.intCityId;
                    _objuser.int_StateId = _objdata.intStateId;
                    _objuser.int_CityId = _objdata.intCityId;
                    _objuser.v_address = _objdata.strAddress;
                    _objuser.v_Password = _objdata.strPassword;
                    _objuser.dt_CreatedOn = DateTime.Now;
                    _objuser.b_IsActive = true;
                    dataContext.tbl_All_User.Add(_objuser);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "User save sucessfully.";
                    return _objdata;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserModel UpdateUser(UserModel _objdata)
        {
            tbl_All_User _objproduct = new tbl_All_User();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_All_User.Where(x => x.int_id == _objdata.intUserId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_All_User _log = new tbl_All_User();

                        _log = dataContext.tbl_All_User.Where(x => x.int_id == _objdata.intUserId).FirstOrDefault();
                        _log.v_FirstName = _objdata.strFirstName;
                        _log.v_LastName = _objdata.strLastName;
                        _log.v_EmailId = _objdata.strEmailId;
                        _log.v_MobileNo = _objdata.strMobileNo;
                        _log.int_CountryId = _objdata.intCityId;
                        _log.int_StateId = _objdata.intStateId;
                        _log.int_CityId = _objdata.intCityId;
                        _log.v_address = _objdata.strAddress;
                        _log.v_Password = _objdata.strPassword;
                        _log.dt_CreatedOn = DateTime.Now;
                        _log.b_IsActive = true;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Product updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CountryList> GetCountryList()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<CountryList> _listBrand = new List<CountryList>();
                dataContext.Database.Connection.Open();
                _listBrand = (from _country in dataContext.tbl_Countries.AsEnumerable()
                              where _country.b_IsActive == true
                              select new CountryList
                              {
                                  int_id = _country.int_Id,
                                  v_name = _country.v_country
                              }).ToList();
                _listBrand.Insert(0, new CountryList { v_name = "--Select Country--", int_id = 0 });
                return _listBrand;

            }
        }

        public List<CityList> GetCityList()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<CityList> _listCity = new List<CityList>();
                dataContext.Database.Connection.Open();
                _listCity = (from _city in dataContext.tbl_Cities.AsEnumerable()
                             where _city.b_flag==true
                             select new CityList
                             {
                                 int_id = _city.int_Id,
                                 v_name = _city.v_City
                             }).ToList();
                _listCity.Insert(0, new CityList { v_name = "--Select City--", int_id = 0 });
                return _listCity;

            }
        }

        public List<StateList> GetStateList()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<StateList> _listBrand = new List<StateList>();
                dataContext.Database.Connection.Open();
                _listBrand = (from _state in dataContext.tbl_States.AsEnumerable()
                              where _state.b_IsActive == true
                              select new StateList
                              {
                                  int_id = _state.int_Id,
                                  v_name = _state.v_State
                              }).ToList();
                _listBrand.Insert(0, new StateList { v_name = "--Select State--", int_id = 0 });
                return _listBrand;

            }
        }

        public List<UserTypeList> GetUserTypeList()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<UserTypeList> _listUserType = new List<UserTypeList>();
                dataContext.Database.Connection.Open();
                _listUserType = (from _usertype in dataContext.tbl_User_Types.AsEnumerable()
                              select new UserTypeList
                              {
                                  int_id = _usertype.int_Id,
                                  v_User_Type = _usertype.v_name
                              }).ToList();
                _listUserType.Insert(0, new UserTypeList { v_User_Type = "--Select User Type--", int_id = 0 });
                return _listUserType;

            }
        }

        public UserModel GetUserById(UserModel _usermodal)
        {            
            using (newconecommerce dataContext = new newconecommerce())
            {
                _usermodal = (from x in dataContext.tbl_All_User
                              where x.int_id == _usermodal.intUserId
                              select new UserModel
                              {
                                  intModuleTypeId = (int)x.int_User_Type,
                                  int_id = x.int_id,
                                  strFirstName = x.v_FirstName,
                                  strLastName = x.v_LastName,
                                  strEmailId = x.v_EmailId,
                                  strMobileNo = x.v_MobileNo,
                                  intCountryId = (int)x.int_CountryId,
                                  intCityId = (int)x.int_CityId,
                                  intStateId = (int)x.int_StateId,
                                  strAddress = x.v_address,
                                  strPassword = x.v_Password
                              }).FirstOrDefault();

                return _usermodal;
            }
        }
    }
}
