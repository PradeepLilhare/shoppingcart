using ShoppingCore.Repository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingWebApi.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService _order;
        public OrderController()
        {
            _order = new OrderService();
        }

        [HttpPost]
        [Route("api/AddProductTocart")]
        public HttpResponseMessage addProductTocart([FromBody] AddToCartModel lstaddtocart)
        {
            var result = _order.AddToCart(lstaddtocart);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        [HttpPost]
        [Route("api/GetProductCartByUserId")]
        public HttpResponseMessage getCartByRetailerId([FromBody] AddToCartModel lstaddtocart)
        {
            var result = _order.getProductCartByUserId(lstaddtocart);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

       
    }
}
