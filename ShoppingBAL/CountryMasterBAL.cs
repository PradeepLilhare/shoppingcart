using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
    public class CountryMasterBAL
    {
        CountryMasterDataAccess _dataaccess = new CountryMasterDataAccess();

        public List<CountryModel> CountryModelsList(List<CountryModel> _listCountry)
        {
            return _dataaccess.CountryMastersList(_listCountry);
        }
        public CountryModel SaveCountry(CountryModel _objproduct)
        {
            return _dataaccess.SaveCountry(_objproduct);
        }
        public CountryModel UpdateCountry(CountryModel _objCountry)
        {
            return _dataaccess.UpdateCountry(_objCountry);
        }
        public CountryModel DeleteCountry(int intCountryId)
        {
            return _dataaccess.DeleteCountry(intCountryId);
        }
        public CountryModel GetCountryById(CountryModel _Countrymodal)
        {
            return _dataaccess.GetCountryById(_Countrymodal);
        }
    }
}
