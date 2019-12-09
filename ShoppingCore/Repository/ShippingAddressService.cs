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

namespace ShoppingCore.Repository
{
    public class ShippingAddressService : IShippingAddressService
    {
        public object GetCountry()
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<CountryModel> _list = (from _country in dataContext.tbl_Countries
                                                where _country.b_IsActive == true
                                                select new CountryModel
                                                {
                                                    intCountryId = _country.int_Id,
                                                    strCountryName = _country.v_country,
                                                    strCourncy = _country.v_currency,
                                                    strCourncySymbol = _country.v_currency_symbol
                                                }).ToList();

                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _list };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetState(int intCountryId)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<StateModel> _list = (from _state in dataContext.tbl_States
                                              join _country in dataContext.tbl_Countries on _state.int_CountryId equals _country.int_Id
                                              where _country.b_IsActive == true && _state.b_IsActive == true && _state.int_CountryId == intCountryId
                                              select new StateModel
                                              {
                                                  intStateId = _state.int_Id,
                                                  strStateName = _state.v_State,
                                                  strCountryName = _country.v_country
                                              }).ToList();
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object GetCity(int intStateId)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<CityModel> _list = (from _City in dataContext.tbl_Cities
                                             join _states in dataContext.tbl_States on _City.int_Id equals _states.int_Id
                                             join _country in dataContext.tbl_Countries on _states.int_CountryId equals _country.int_Id
                                             where _country.b_IsActive == true && _City.b_flag == true && _City.int_State_Id == intStateId
                                             select new CityModel
                                             {
                                                 intCityId = _City.int_Id,
                                                 strCityName = _City.v_City,
                                                 intStateId = _states.int_Id,
                                                 strStateName = _states.v_State,
                                                 intCountryId = _country.int_Id,
                                                 strCountryName = _country.v_country
                                             }).ToList();
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object AddUserAddress(ShippingAddressModel _address)
        {
            try
            {
                ResShippingAddress _response = new ResShippingAddress();

                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var command = dataContext.Database.Connection.CreateCommand();
                    command.CommandText = "usp_Shipping_Address";
                    command.CommandType = CommandType.StoredProcedure;
                    var p = new SqlParameter("@intUserid", _address.intUserid);
                    var p1 = new SqlParameter("@strAddress", _address.strAddress);
                    var p2 = new SqlParameter("@intCityid", _address.intCityId);
                    var p3 = new SqlParameter("@intStateid", _address.intStateId);
                    var p4 = new SqlParameter("@intCountryId", _address.intCountryId);
                    var p5 = new SqlParameter("@strPin", _address.strPin);
                    var p6 = new SqlParameter("@strMobileNo", _address.strMobileNo);
                    var p7 = new SqlParameter("@StrAction", _address.strAction);
                    var p8 = new SqlParameter("@intShippingid", _address.intShippingid);
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);
                    command.Parameters.Add(p5);
                    command.Parameters.Add(p6);
                    command.Parameters.Add(p7);
                    command.Parameters.Add(p8);
                    var reader = command.ExecuteReader();
                    DataSet oDS = new DataSet();
                    while (!reader.IsClosed)
                        oDS.Tables.Add().Load(reader);
                 
                    if (oDS.Tables[0].Rows.Count != 0)
                    {
                        _response.intShippingid = Convert.ToInt32(oDS.Tables[0].Rows[0]["ShippingId"]);
                        _response.strMsg = oDS.Tables[0].Rows[0]["Msg"].ToString();
                    }
                    dataContext.Database.Connection.Close();
                }

                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _response };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object GetUserAddressById(int intUserId)
        {
            try
            {
                ShippingAddressResponseModel _response = new ShippingAddressResponseModel();

                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var command = dataContext.Database.Connection.CreateCommand();
                    command.CommandText = "usp_Shipping_Address";
                    command.CommandType = CommandType.StoredProcedure;
                    var p = new SqlParameter("@intUserid", intUserId);
                    var p1 = new SqlParameter("@strAddress", "");
                    var p2 = new SqlParameter("@intCityid", 0);
                    var p3 = new SqlParameter("@intStateid", 0);
                    var p4 = new SqlParameter("@intCountryId", 0);
                    var p5 = new SqlParameter("@strPin", "");
                    var p6 = new SqlParameter("@strMobileNo", "");
                    var p7 = new SqlParameter("@StrAction", "GetAllShippingAddress");
                    command.Parameters.Add(p);
                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);
                    command.Parameters.Add(p5);
                    command.Parameters.Add(p6);
                    command.Parameters.Add(p7);
                    var reader = command.ExecuteReader();
                    DataSet oDS = new DataSet();
                    while (!reader.IsClosed)
                        oDS.Tables.Add().Load(reader);

                    if (oDS.Tables[0].Rows.Count != 0)
                    {
                        _response.intShippingid = Convert.ToInt32(oDS.Tables[0].Rows[0]["ShippingId"]);
                        _response.strAddress = oDS.Tables[0].Rows[0]["v_address"].ToString();
                        _response.intCityId =Convert.ToInt32(oDS.Tables[0].Rows[0]["intCityId"]);
                        _response.strCity = oDS.Tables[0].Rows[0]["City"].ToString();
                        _response.intStateId = Convert.ToInt32(oDS.Tables[0].Rows[0]["intStateId"]);
                        _response.strState = oDS.Tables[0].Rows[0]["States"].ToString();
                        _response.intCountryId = Convert.ToInt32(oDS.Tables[0].Rows[0]["intCountryId"]);
                        _response.strCountry = oDS.Tables[0].Rows[0]["Country"].ToString();
                        _response.strPin = oDS.Tables[0].Rows[0]["v_pin"].ToString();
                        _response.strMobileNo = oDS.Tables[0].Rows[0]["v_mobile_no"].ToString();
                    }
                    dataContext.Database.Connection.Close();
                }

                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _response };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
