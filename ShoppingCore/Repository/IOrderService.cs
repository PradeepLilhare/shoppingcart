using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
   public interface IOrderService
    {
        object AddToCart(AddToCartModel addtocart);

        object getProductCartByUserId(AddToCartModel addtocart);
       
    }
}
