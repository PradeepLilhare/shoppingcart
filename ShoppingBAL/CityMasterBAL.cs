using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
   public class CityMasterBAL
    {
        CityMasterDataAccess _dataaccess = new CityMasterDataAccess();

        public List<CityModel> CityMastersList(List<CityModel> _listCity)
        {
            return _dataaccess.CityMastersList(_listCity);
        }
        public CityModel SaveCity(CityModel _objCity)
        {
            return _dataaccess.SaveCity(_objCity);
        }
        public CityModel UpdateCity(CityModel _objCity)
        {
            return _dataaccess.UpdateCity(_objCity);
        }
        public CityModel DeleteCity(int intCityId)
        {
            return _dataaccess.DeleteCity(intCityId);
        }
        public List<CountryModel> GetCountry()
        {
            return _dataaccess.GetCountry();
        }
        public List<StateModel> GetState()
        {
            return _dataaccess.GetState();
        }

        public CityModel GetCityById(CityModel _Citymodal)
        {
            return _dataaccess.GetCityById(_Citymodal);
        }
    }
}
