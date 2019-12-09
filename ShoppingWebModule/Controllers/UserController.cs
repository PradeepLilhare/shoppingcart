using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class UserController : Controller
    {
        UserOperationBAL _objuserBAL = new UserOperationBAL();
        // GET: Product
        public ActionResult Index(List<UserModel> _listUserModel)
        {
            List<UserModel> _listproduct = new List<UserModel>();
            _listUserModel = _objuserBAL.UserMastersList(_listproduct);
            return View(_listUserModel);
        }

        [HttpGet]
        public ActionResult SaveUser(int intUserId)
        {
            UserModel _viewUserModal = new UserModel();
            _viewUserModal.intUserId = intUserId;
            List<CountryList> _listCountry = new List<CountryList>();
            List<StateList> _listState = new List<StateList>();
            List<CityList> _listCity = new List<CityList>();
            List<UserTypeList> _listUserType = new List<UserTypeList>();

            _listCountry = _objuserBAL.GetCountryList();
            _listCity = _objuserBAL.GetCityList();
            _listState = _objuserBAL.GetStateList();
            _listUserType = _objuserBAL.GetUserTypeList();


            if (_viewUserModal.intUserId != 0)
                _viewUserModal = _objuserBAL.GetUserListById(_viewUserModal);

            _viewUserModal._listCountry = _listCountry;
            _viewUserModal._listState = _listState;
            _viewUserModal._listCity = _listCity;
            _viewUserModal._listUserType = _listUserType;

            return View(_viewUserModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUser(HttpPostedFileBase file, UserModel _viewUserModal)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                List<CountryList> _listCountry = new List<CountryList>();
                List<StateList> _listState = new List<StateList>();
                List<CityList> _listCity = new List<CityList>();
                List<UserTypeList> _listUserType = new List<UserTypeList>();

                _listCountry = _objuserBAL.GetCountryList();
                _listCity = _objuserBAL.GetCityList();
                _listState = _objuserBAL.GetStateList();
                _listUserType = _objuserBAL.GetUserTypeList();

                _viewUserModal._listCountry = _listCountry;
                _viewUserModal._listState = _listState;
                _viewUserModal._listCity = _listCity;
                _viewUserModal._listUserType = _listUserType;


                if ((_viewUserModal.intUserId == null) || ((_viewUserModal.intUserId == 0)))
                    _objuserBAL.SaveUser(_viewUserModal);
                else
                    _objuserBAL.UpdateUser(_viewUserModal);

                ModelState.AddModelError("", _viewUserModal.StatusMessaage);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "User");
        }
    }
}