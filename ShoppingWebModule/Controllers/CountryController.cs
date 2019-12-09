using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class CountryController : Controller
    {
        CountryMasterBAL _objbrandBAL = new CountryMasterBAL();
        public ActionResult Index(List<CountryModel> _listCountryModel)
        {
            List<CountryModel> _listbrand = new List<CountryModel>();
            _listCountryModel = _objbrandBAL.CountryModelsList(_listbrand);
            return View(_listCountryModel);
        }

        [HttpGet]
        public ActionResult SaveCountry(int intCountryId)
        {
            CountryModel _viewBrandModal = new CountryModel();
            _viewBrandModal.intCountryId = intCountryId;
            _viewBrandModal = _objbrandBAL.GetCountryById(_viewBrandModal);
            return View(_viewBrandModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCountry(CountryModel _viewBrandModal)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (_viewBrandModal.intCountryId == 0)
                    _objbrandBAL.SaveCountry(_viewBrandModal);
                else
                    _objbrandBAL.UpdateCountry(_viewBrandModal);

                ModelState.AddModelError("", _viewBrandModal.StatusMessaage);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "Country");
        }

        [HttpGet]
        public ActionResult DeleteCountry(int intCountryId)
        {
            _objbrandBAL.DeleteCountry(intCountryId);
            return RedirectToAction("Index", "Country");
        }
    }
}