using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class ProductController : Controller
    {
        ProductMasterBAL _objproductBAL = new ProductMasterBAL();
        // GET: Product
        public ActionResult Index(List<ProductMaster> _listProductMaster)
        {
            List<ProductMaster> _listproduct = new List<ProductMaster>();
            _listProductMaster = _objproductBAL.ProductMastersList(_listproduct);
            return View(_listProductMaster);
        }

        [HttpGet]
        public ActionResult SaveProduct(int intProductId)
        {
            ProductModal _viewProductModal = new ProductModal();
            _viewProductModal.intProductId = intProductId;
            List<ProductBrands> _listBrand = new List<ProductBrands>();
            List<ProductCategory> _listCategory = new List<ProductCategory>();

            _listBrand = _objproductBAL.GetBrands();
            _listCategory = _objproductBAL.GetCategory();

            if (_viewProductModal.intProductId != 0)
                _viewProductModal = _objproductBAL.GetProductById(_viewProductModal);

            _viewProductModal._listBrand = _listBrand;
            _viewProductModal._listCategory = _listCategory;

            return View(_viewProductModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProduct(HttpPostedFileBase file, ProductModal _viewProductModal)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                List<ProductBrands> _listBrand = new List<ProductBrands>();
                List<ProductCategory> _listCategory = new List<ProductCategory>();

                _listBrand = _objproductBAL.GetBrands();
                _listCategory = _objproductBAL.GetCategory();

                _viewProductModal._listBrand = _listBrand;
                _viewProductModal._listCategory = _listCategory;

                if (file != null)
                {
                    string strImgName = System.IO.Path.GetFileName(file.FileName);
                    string strPath = Server.MapPath("~/Content/product/");
                    if (!Directory.Exists(strPath))
                    {
                        Directory.CreateDirectory(strPath);
                    }
                    else
                        strPath = Server.MapPath("~/Content/product/");

                    string strImagePath = Server.MapPath("~/Content/product/" + strImgName);

                    file.SaveAs(strImagePath);
                    _viewProductModal.strImagePath = strImgName;
                    if (_viewProductModal.intProductId == 0)
                        _objproductBAL.SaveProduct(_viewProductModal);
                    else
                        _objproductBAL.UpdateProduct(_viewProductModal);

                    ModelState.AddModelError("", _viewProductModal.StatusMessaage);
                }
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]       
        public ActionResult DeleteProduct(int intProductId)
        {
            _objproductBAL.DeleteProduct(intProductId);
            return RedirectToAction("Index", "Product");
        }
    }
}