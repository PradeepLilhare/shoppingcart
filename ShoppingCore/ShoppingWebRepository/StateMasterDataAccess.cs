using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class StateMasterDataAccess
    {
        public List<StateModel> StateMastersList(List<StateModel> _listState)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<StateModel> _list = (from _state in dataContext.tbl_States
                                              join _country in dataContext.tbl_Countries on _state.int_CountryId equals _country.int_Id
                                              where _country.b_IsActive == true && _state.b_IsActive == true
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

        public StateModel SaveState(StateModel _objdata)
        {
            tbl_States _objState = new tbl_States();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    _objState.v_State = _objdata.strStateName;
                    _objState.int_CountryId = _objdata.intCountryId;
                    _objState.dt_Created_On = DateTime.Now;
                    _objState.b_IsActive = true;
                    dataContext.tbl_States.Add(_objState);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "State save sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StateModel UpdateState(StateModel _objdata)
        {
            tbl_States _objproduct = new tbl_States();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_States.Where(x => x.int_Id == _objdata.intStateId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_States _log = new tbl_States();

                        _log = dataContext.tbl_States.Where(x => x.int_Id == _objdata.intStateId).FirstOrDefault();
                        _log.v_State = _objdata.strStateName;
                        _log.int_CountryId = _objdata.intCountryId;
                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "State Updated sucessfully.";
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

        public StateModel GetStateById(StateModel _statemodal)
        {
            StateModel _objstate = new StateModel();
            using (newconecommerce dataContext = new newconecommerce())
            {
                _objstate = (from x in dataContext.tbl_States
                             where x.int_Id == _statemodal.intStateId
                             select new StateModel
                             {
                                 strStateName = x.v_State,
                                 intCountryId = (int)x.int_CountryId
                             }).FirstOrDefault();

                return _objstate;
            }
        }
        public StateModel DeleteState(int intStateId)
        {
            StateModel _objdata = new StateModel();
            tbl_States _objState = new tbl_States();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_States.Where(x => x.int_Id == intStateId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_States _log = new tbl_States();

                        _log = dataContext.tbl_States.Where(x => x.int_Id == intStateId).FirstOrDefault();
                        _log.b_IsActive = false;                     

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "State deleted sucessfully.";
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
