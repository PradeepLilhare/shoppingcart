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
    public class UserController : ApiController
    {
        private readonly IUserService _userservice;
        public UserController()
        {
            _userservice = new UserService();
        }

        [HttpPost]
        [Route("api/User/UserSignUp")]
        public HttpResponseMessage UserSignUp([FromBody] UserModel _userRequest)
        {
            var requestdata = _userRequest;
            var loginresponse = _userservice.UserSignUp(_userRequest);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }


        [HttpPost]
        [Route("api/User/UpdateUser")]
        public HttpResponseMessage UpdateUser([FromBody] UserModel _userRequest)
        {
            var requestdata = _userRequest;
            var loginresponse = _userservice.UpdateUser(_userRequest);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }


        [HttpGet]
        [Route("api/User/GetUserList")]
        public HttpResponseMessage GetUserList()
        {            
            var loginresponse = _userservice.GetUserList();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }


        [HttpGet]
        [Route("api/User/GetUserById")]
        public HttpResponseMessage GetUserById(int intUserId)
        {           
            var loginresponse = _userservice.GetUserById(intUserId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }
    }
}
