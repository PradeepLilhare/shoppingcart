using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
    public class CountryModel:ResponseModel
    {
        public int intCountryId { get; set; }

        public string strCountryName { get; set; }

        public string strCourncy { get; set; }

        public string strCourncySymbol { get; set; }
    }
}
