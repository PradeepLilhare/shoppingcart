using ShoppingCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        private readonly IProductService _userservice;
        public ProductController()
        {
            _userservice = new ProductService();
        }

        [HttpGet]
        [Route("api/Product/GetAllProductList")]
        public HttpResponseMessage UserSignUp()
        {            
            var loginresponse = _userservice.GetAllProductList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }
    }
}
