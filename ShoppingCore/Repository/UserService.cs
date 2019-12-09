using ShoppingDataAccess;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
    public class UserService : IUserService
    {
        private newconecommerce dataContext = DBDatacontext.DataContext;

        public object UserSignUp(UserModel _objdata)
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
                    _objuser.int_CountryId = _objdata.intCountryId;
                    _objuser.int_StateId = _objdata.intStateId;
                    _objuser.int_CityId = _objdata.intCityId;
                    _objuser.v_address = _objdata.strAddress;
                    _objuser.v_Pin = _objdata.strPin;
                    _objuser.v_Password = _objdata.strPassword;
                    _objuser.dt_CreatedOn = DateTime.Now;
                    _objuser.b_IsActive = true;
                    dataContext.tbl_All_User.Add(_objuser);
                    dataContext.SaveChanges();
                    UserModel _model = new UserModel();
                    _model.intUserId = _objuser.int_id;
                    dataContext.Database.Connection.Close();
                    if (_model.intUserId != 0)
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = "User save sucessfully." };
                    else
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = "something went wrong" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object UpdateUser(UserModel _objdata)
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

                }
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = "User update sucessfully." };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetUserList()
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    UserModelList _userList = new UserModelList();
                    List<CountryList> _listCountry = new List<CountryList>();
                    List<CityList> _listCity = new List<CityList>();
                    List<StateList> _listState = new List<StateList>();
                    List<UserTypeList> _listUserType = new List<UserTypeList>();

                    dataContext.Database.Connection.Open();

                    _listCity = (from _city in dataContext.tbl_Cities.AsEnumerable()
                                 where _city.b_flag == true
                                 select new CityList
                                 {
                                     int_id = _city.int_Id,
                                     v_name = _city.v_City
                                 }).ToList();


                    _listState = (from _state in dataContext.tbl_States.AsEnumerable()
                                  where _state.b_IsActive == true
                                  select new StateList
                                  {
                                      int_id = _state.int_Id,
                                      v_name = _state.v_State
                                  }).ToList();


                    _listCountry = (from _country in dataContext.tbl_Countries.AsEnumerable()
                                    where _country.b_IsActive == true
                                    select new CountryList
                                    {
                                        int_id = _country.int_Id,
                                        v_name = _country.v_country
                                    }).ToList();

                    _listUserType = (from _usertype in dataContext.tbl_User_Types.AsEnumerable()
                                     select new UserTypeList
                                     {
                                         int_id = _usertype.int_Id,
                                         v_User_Type = _usertype.v_name
                                     }).ToList();


                    _listState.Insert(0, new StateList { v_name = "--Select State--", int_id = 0 });
                    _listCity.Insert(0, new CityList { v_name = "--Select City--", int_id = 0 });
                    _listCountry.Insert(0, new CountryList { v_name = "--Select Country--", int_id = 0 });
                    _listUserType.Insert(0, new UserTypeList { v_User_Type = "--Select User Type--", int_id = 0 });

                    _userList._listUserType = _listUserType;
                    _userList._listCity = _listCity;
                    _userList._listState = _listState;
                    _userList._listCountry = _listCountry;

                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _userList };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetUserById(int intUserId)
        {
            try
            {
                UserModel _usermodal = new UserModel();
                using (newconecommerce dataContext = new newconecommerce())
                {
                    _usermodal = (from x in dataContext.tbl_All_User
                                  where x.int_id == intUserId
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
                                      strPin = x.v_Pin,
                                      strPassword = x.v_Password
                                  }).FirstOrDefault();

                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _usermodal };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public object GetCityList()
        //{
        //    try
        //    {
        //        using (newconecommerce dataContext = new newconecommerce())
        //        {
        //            List<CityList> _listCity = new List<CityList>();
        //            dataContext.Database.Connection.Open();
        //            _listCity = (from _city in dataContext.tbl_Cities.AsEnumerable()
        //                         where _city.b_flag == true
        //                         select new CityList
        //                         {
        //                             int_id = _city.int_Id,
        //                             v_name = _city.v_City
        //                         }).ToList();
        //            _listCity.Insert(0, new CityList { v_name = "--Select City--", int_id = 0 });


        //            return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _listCity };

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetStateList()
        //{
        //    try
        //    {
        //        using (newconecommerce dataContext = new newconecommerce())
        //        {
        //            List<StateList> _listState = new List<StateList>();
        //            dataContext.Database.Connection.Open();
        //            _listState = (from _state in dataContext.tbl_States.AsEnumerable()
        //                          where _state.b_IsActive == true
        //                          select new StateList
        //                          {
        //                              int_id = _state.int_Id,
        //                              v_name = _state.v_State
        //                          }).ToList();
        //            _listState.Insert(0, new StateList { v_name = "--Select State--", int_id = 0 });

        //            return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _listState };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    using (newconecommerce dataContext = new newconecommerce())
        //    {
        //        List<StateList> _listState = new List<StateList>();
        //        dataContext.Database.Connection.Open();
        //        _listState = (from _state in dataContext.tbl_States.AsEnumerable()
        //                      where _state.b_IsActive == true
        //                      select new StateList
        //                      {
        //                          int_id = _state.int_Id,
        //                          v_name = _state.v_State
        //                      }).ToList();
        //        _listState.Insert(0, new StateList { v_name = "--Select State--", int_id = 0 });

        //        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _listState };
        //    }
        //}

        //public object GetUserTypeList()
        //{
        //    try
        //    {
        //        using (newconecommerce dataContext = new newconecommerce())
        //        {
        //            List<UserTypeList> _listUserType = new List<UserTypeList>();
        //            dataContext.Database.Connection.Open();
        //            _listUserType = (from _usertype in dataContext.tbl_User_Types.AsEnumerable()
        //                             select new UserTypeList
        //                             {
        //                                 int_id = _usertype.int_Id,
        //                                 v_User_Type = _usertype.v_name
        //                             }).ToList();
        //            _listUserType.Insert(0, new UserTypeList { v_User_Type = "--Select User Type--", int_id = 0 });

        //            return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _listUserType };

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetUserById(UserModel _usermodal)
        //{
        //    try
        //    {
        //        using (newconecommerce dataContext = new newconecommerce())
        //        {
        //            _usermodal = (from x in dataContext.tbl_All_User
        //                          where x.int_id == _usermodal.intUserId
        //                          select new UserModel
        //                          {
        //                              intModuleTypeId = (int)x.int_User_Type,
        //                              int_id = x.int_id,
        //                              strFirstName = x.v_FirstName,
        //                              strLastName = x.v_LastName,
        //                              strEmailId = x.v_EmailId,
        //                              strMobileNo = x.v_MobileNo,
        //                              intCountryId = (int)x.int_CountryId,
        //                              intCityId = (int)x.int_CityId,
        //                              intStateId = (int)x.int_StateId,
        //                              strAddress = x.v_address,
        //                              strPassword = x.v_Password
        //                          }).FirstOrDefault();

        //            return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _usermodal };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
    }
}
