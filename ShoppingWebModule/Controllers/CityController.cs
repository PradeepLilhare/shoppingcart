using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class CityController : Controller
    {
        CityMasterBAL _objCityBAL = new CityMasterBAL();
        public ActionResult Index(List<CityModel> _listStateMaster)
        {
            List<CityModel> _listCity = new List<CityModel>();
            _listStateMaster = _objCityBAL.CityMastersList(_listCity);
            return View(_listStateMaster);
        }

        [HttpGet]
        public ActionResult SaveUpdateCity(int intCityId)
        {
            CityModel _viewCityModal = new CityModel();
            _viewCityModal.intCityId = intCityId;

            List<CountryModel> _listCountry = new List<CountryModel>();
            List<StateModel> _listState = new List<StateModel>();

            _listCountry = _objCityBAL.GetCountry();
            _listState = _objCityBAL.GetState();

            if (_viewCityModal.intCityId != 0)
                _viewCityModal = _objCityBAL.GetCityById(_viewCityModal);

            _viewCityModal._listCountry = _listCountry;
            _viewCityModal._listState = _listState;
            return View(_viewCityModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUpdateCity(CityModel _viewCityModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (_viewCityModel.intCityId == 0)
                    _objCityBAL.SaveCity(_viewCityModel);
                else
                    _objCityBAL.UpdateCity(_viewCityModel);

                ModelState.AddModelError("", _viewCityModel.StatusMessaage);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "City");
        }
        [HttpGet]
        public ActionResult DeleteCity(int intCityId)
        {
            _objCityBAL.DeleteCity(intCityId);
            return RedirectToAction("Index", "City");
        }
    }
}