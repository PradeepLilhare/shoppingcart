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
    
    public class LoginController : ApiController
    {
        private readonly ILoginService loginService;
        public LoginController()
        {
            loginService = new LoginService();
        }

        [HttpPost]       
        [Route("api/login/login")]
        public HttpResponseMessage login([FromBody] UserModel _loginRequest)
        {
            var requestdata = _loginRequest;
            var loginresponse = loginService.CheckLogin(_loginRequest);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }
        [HttpPost]
        [Route("api/login/PostLogindtl/")]
        public HttpResponseMessage PostLogindtl(Postloginreq _login)
        {
            var loginresponse = loginService.PostLogin(_login);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }
        [HttpPost]
        [Route("api/login/PostLogoutdtl/")]
        public HttpResponseMessage PostLogoutdtl(Postloginreq _login)
        {     
            var loginresponse = loginService.PostLogout(_login);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }
        [HttpPost]
        [Route("api/login/ChangePassword/")]
        public HttpResponseMessage ChangePassword([FromBody] UserModel _changePasswordRequest)
        {
            var loginresponse = loginService.ChangePassword(Convert.ToInt32(_changePasswordRequest.int_id), _changePasswordRequest.strPassword, (int)_changePasswordRequest.intModuleTypeId, _changePasswordRequest.strOldPassword);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }

        [HttpPost]
        [Route("api/login/ForgotPassword/")]
        public HttpResponseMessage ForgotPassword([FromBody] UserModel _changeForgotPasswordRequest)
        {
            var loginresponse = loginService.ForgotPassword(_changeForgotPasswordRequest.strEmailId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, loginresponse);
            return response;
        }
    }
}
