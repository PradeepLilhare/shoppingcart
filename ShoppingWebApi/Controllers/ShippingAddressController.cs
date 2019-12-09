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
    public class ShippingAddressController : ApiController
    {
        private readonly IShippingAddressService _address;
        public ShippingAddressController()
        {
            _address = new ShippingAddressService();
        }
        [HttpGet]
        [Route("api/GetCountry")]
        public HttpResponseMessage GetCountry()
        {
            var result = _address.GetCountry();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpGet]
        [Route("api/GetState")]
        public HttpResponseMessage GetState(int intCountryId)
        {
            var result = _address.GetState(intCountryId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        [HttpGet]
        [Route("api/GetCity")]
        public HttpResponseMessage GetCity(int intStateId)
        {
            var result = _address.GetCity(intStateId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [HttpPost]
        [Route("api/AddUserAddress")]
        public HttpResponseMessage AddUserAddress([FromBody] ShippingAddressModel _Shipaddress)
        {
            var result = _address.AddUserAddress(_Shipaddress);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [HttpGet]
        [Route("api/GetUserAddressById")]
        public HttpResponseMessage GetUserAddressById(int intUserId)
        {
            var result = _address.GetUserAddressById(intUserId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
    }
}
