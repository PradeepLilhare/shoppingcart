using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class BrandController : Controller
    {
        BrandMasterBAL _objbrandBAL = new BrandMasterBAL();
        public ActionResult Index(List<BrandModel> _listBrandModel)
        {
            List<BrandModel> _listbrand = new List<BrandModel>();
            _listBrandModel = _objbrandBAL.BrandModelsList(_listbrand);
            return View(_listBrandModel);
        }

        [HttpGet]
        public ActionResult SaveBrand(int intBrandId)
        {
            BrandModel _viewBrandModal = new BrandModel();
            _viewBrandModal.intBrandId = intBrandId;
            _viewBrandModal = _objbrandBAL.GetBrandById(_viewBrandModal);
            return View(_viewBrandModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveBrand(BrandModel _viewBrandModal)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (_viewBrandModal.intBrandId == 0)
                    _objbrandBAL.SaveBrand(_viewBrandModal);
                else
                    _objbrandBAL.UpdateBrand(_viewBrandModal);

                ModelState.AddModelError("", _viewBrandModal.StatusMessaage);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "Brand");
        }

        [HttpGet]
        public ActionResult DeleteBrand(int intBrandId)
        {
            _objbrandBAL.DeleteBrand(intBrandId);
            return RedirectToAction("Index", "Brand");
        }
    }
}