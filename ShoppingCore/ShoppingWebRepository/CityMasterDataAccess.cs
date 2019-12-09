using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class CityMasterDataAccess
    {
        public List<CityModel> CityMastersList(List<CityModel> _listCity)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<CityModel> _list = (from _City in dataContext.tbl_Cities
                                             join _states in dataContext.tbl_States on _City.int_Id equals _states.int_Id
                                             join _country in dataContext.tbl_Countries on _states.int_CountryId equals _country.int_Id
                                             where _country.b_IsActive == true && _City.b_flag == true
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

        public CityModel SaveCity(CityModel _objdata)
        {
            tbl_Cities _objCity = new tbl_Cities();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    _objCity.v_City = _objdata.strCityName;
                    _objCity.int_State_Id = _objdata.intStateId;                    
                    _objCity.b_flag = true;
                    dataContext.tbl_Cities.Add(_objCity);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "City save sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public CityModel UpdateCity(CityModel _objdata)
        {
            tbl_Cities _objproduct = new tbl_Cities();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Cities.Where(x => x.int_Id == _objdata.intCityId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Cities _log = new tbl_Cities();

                        _log = dataContext.tbl_Cities.Where(x => x.int_Id == _objdata.intCityId).FirstOrDefault();
                        _log.v_City = _objdata.strCityName;
                        _log.int_State_Id = _objdata.intStateId;
                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "City Updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CountryModel> GetCountry()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<CountryModel> _listCountry = new List<CountryModel>();
                dataContext.Database.Connection.Open();
                _listCountry = (from _country in dataContext.tbl_Countries.AsEnumerable()
                                select new CountryModel
                                {
                                    intCountryId = _country.int_Id,
                                    strCountryName = _country.v_country
                                }).ToList();
                _listCountry.Insert(0, new CountryModel { strCountryName = "--Select Country--" });
                return _listCountry;

            }
        }
        public List<StateModel> GetState()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<StateModel> _listState = new List<StateModel>();
                dataContext.Database.Connection.Open();
                _listState = (from _state in dataContext.tbl_States.AsEnumerable()
                                select new StateModel
                                {
                                    intStateId = _state.int_Id,
                                    strStateName = _state.v_State
                                }).ToList();
                _listState.Insert(0, new StateModel { strStateName = "--Select State--" });
                return _listState;

            }
        }

        public CityModel GetCityById(CityModel _Citymodal)
        {
            CityModel _objCity = new CityModel();
            using (newconecommerce dataContext = new newconecommerce())
            {
                _objCity = (from x in dataContext.tbl_Cities
                            join _state in dataContext.tbl_States on x.int_Id equals _state.int_Id                        
                            where x.int_Id == _Citymodal.intCityId
                            select new CityModel
                            {
                                strCityName = x.v_City,
                                intCityId = (int)x.int_Id,
                                intStateId=(int)x.int_State_Id,
                                intCountryId=(int)_state.int_CountryId
                            }).FirstOrDefault();

                return _objCity;
            }
        }
        public CityModel DeleteCity(int intCityId)
        {
            CityModel _objdata = new CityModel();
            tbl_Cities _objCity = new tbl_Cities();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Cities.Where(x => x.int_Id == intCityId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Cities _log = new tbl_Cities();

                        _log = dataContext.tbl_Cities.Where(x => x.int_Id == intCityId).FirstOrDefault();
                        _log.b_flag = false;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "City deleted sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
