using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
    public class StateModel : ResponseModel
    {
        public int intStateId { get; set; }

        public string strStateName { get; set; }

        public int intCountryId { get; set; }
        public string strCountryName { get; set; }

        public List<CountryModel> _listCountry;
       
    }
    //public class CountryListData
    //{
    //    public int intCountryId { get; set; }

    //    public string strCountryName { get; set; }
    //}
}
