using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class CategoryController : Controller
    {
        CategoryMasterBAL _objcategoryBAL = new CategoryMasterBAL();
        public ActionResult Index(List<CategoryModel> _listcategoryModel)
        {
            List<CategoryModel> _listcategory = new List<CategoryModel>();
            _listcategoryModel = _objcategoryBAL.CategoryModelsList(_listcategory);
            return View(_listcategoryModel);
        }

        [HttpGet]
        public ActionResult Savecategory(int intcategoryId)
        {
            CategoryModel _viewcategoryModal = new CategoryModel ();
            _viewcategoryModal.intCategoryId = intcategoryId;
            _viewcategoryModal = _objcategoryBAL.GetCategoryById(_viewcategoryModal);
            return View(_viewcategoryModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Savecategory(CategoryModel _viewcategoryModal)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (_viewcategoryModal.intCategoryId == 0)
                    _objcategoryBAL.SaveCategory(_viewcategoryModal);
                else
                    _objcategoryBAL.UpdateCategory(_viewcategoryModal);

                ModelState.AddModelError("", _viewcategoryModal.StatusMessaage);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public ActionResult Deletecategory(int intCategoryId)
        {
            _objcategoryBAL.DeleteCategory(intCategoryId);
            return RedirectToAction("Index", "Category");
        }
    }
}
