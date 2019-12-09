using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
    public class CityModel:ResponseModel
    {
        public int intCityId { get; set; }

        public string strCityName { get; set; }

        public int intStateId { get; set; }

        public string strStateName { get; set; }

        public int intCountryId { get; set; }

        public string strCountryName { get; set; }

        public List<StateModel> _listState;
        public List<CountryModel> _listCountry;

    }
}
