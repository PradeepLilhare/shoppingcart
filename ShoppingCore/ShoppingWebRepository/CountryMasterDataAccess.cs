using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class CountryMasterDataAccess
    {
        public List<CountryModel> CountryMastersList(List<CountryModel> _listCountry)
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
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CountryModel SaveCountry(CountryModel _objdata)
        {
            tbl_Countries _objCountry = new tbl_Countries();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    _objCountry.v_country = _objdata.strCountryName;
                    _objCountry.v_currency = _objdata.strCourncy;
                    _objCountry.v_currency_symbol = _objdata.strCourncySymbol;
                    _objCountry.b_IsActive = true;
                    dataContext.tbl_Countries.Add(_objCountry);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "Country save sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public CountryModel UpdateCountry(CountryModel _objdata)
        {
            tbl_Countries _objCountry = new tbl_Countries();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();

                    var _query = dataContext.tbl_Countries.Where(x => x.int_Id == _objdata.intCountryId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Countries _objTemp = new tbl_Countries();

                        _objTemp = dataContext.tbl_Countries.Where(x => x.int_Id == _objdata.intCountryId).FirstOrDefault();
                        _objTemp.v_country = _objdata.strCountryName;
                        _objTemp.v_currency = _objdata.strCourncy;
                        _objTemp.v_currency_symbol = _objdata.strCourncySymbol;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Country updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public CountryModel GetCountryById(CountryModel _CountryModel)
        {
            CountryModel _objCountry = new CountryModel();
            using (newconecommerce dataContext = new newconecommerce())
            {
                _objCountry = (from x in dataContext.tbl_Countries
                               where x.int_Id == _CountryModel.intCountryId
                               select new CountryModel
                               {
                                   strCountryName = x.v_country,
                                   strCourncy = x.v_currency,
                                   strCourncySymbol = x.v_currency_symbol,
                               }).AsEnumerable().Select(x => new CountryModel
                               {
                                   strCountryName = x.strCountryName,
                                   strCourncy = x.strCourncy,
                                   strCourncySymbol = x.strCourncySymbol
                               }).FirstOrDefault();

                return _objCountry;
            }
        }

        public CountryModel DeleteCountry(int intCountryId)
        {
            CountryModel _objdata = new CountryModel();
            tbl_Countries _objBrand = new tbl_Countries();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Countries.Where(x => x.int_Id == intCountryId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Countries _log = new tbl_Countries();

                        _log = dataContext.tbl_Countries.Where(x => x.int_Id == intCountryId).FirstOrDefault();
                        _log.b_IsActive = false;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Country deleted sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
