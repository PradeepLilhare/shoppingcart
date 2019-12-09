using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
    public class ShippingAddressModel
    {
        public int intShippingid { get; set; }
        public int intUserid { get; set; }
        public string strAddress { get; set; }
        public int intCityId { get; set; }
        public int intStateId { get; set; }
        public int intCountryId { get; set; }
        public string strPin { get; set; }
        public string strMobileNo { get; set; }
        public string strAction { get; set; }
    }
    public class ResShippingAddress
    {
        public int intShippingid { get; set; }
        public string strMsg { get; set; }
    }
    public class ShippingAddressResponseModel
    {
        public int intShippingid { get; set; }      
        public string strAddress { get; set; }
        public int intCityId { get; set; }
        public string strCity { get; set; }
        public int intStateId { get; set; }
        public string strState { get; set; }
        public int intCountryId { get; set; }
        public string strCountry { get; set; }
        public string strPin { get; set; }
        public string strMobileNo { get; set; }       
    }
}
