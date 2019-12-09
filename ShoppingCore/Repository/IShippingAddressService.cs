using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
    public interface IShippingAddressService
    {
        object GetCountry();

        object GetState(int intCountryId);

        object GetCity(int intStateId);

        object AddUserAddress(ShippingAddressModel _address);

        object GetUserAddressById(int intUserId);
    }
}
