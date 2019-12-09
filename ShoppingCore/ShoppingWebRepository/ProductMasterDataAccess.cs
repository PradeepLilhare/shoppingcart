using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class ProductMasterDataAccess
    {
        public List<ProductMaster> ProductMastersList(List<ProductMaster> _listproduct)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<ProductMaster> _list = (from _product in dataContext.tbl_Products
                                                 join _category in dataContext.tbl_category on _product.int_CategoryId equals _category.int_id
                                                 join _brand in dataContext.tbl_Brands on _product.int_BrandsId equals _brand.int_id
                                                 where _product.b_IsActive==true
                                                 select new ProductMaster
                                                 {
                                                     intProductId = _product.int_id,
                                                     strBrand = _brand.v_name,
                                                     strCategory = _category.v_category,
                                                     strProductName = _product.v_name,
                                                     intStocks = (int)_product.int_quantity,
                                                     dblPrice = (double)_product.fl_price
                                                 }).ToList();
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ProductModal SaveProduct(ProductModal _objdata)
        {
            tbl_Products _objproduct = new tbl_Products();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    _objproduct.v_name = _objdata.strProductName;
                    _objproduct.fl_price = Convert.ToDouble(_objdata.dblPrice);
                    _objproduct.int_quantity = _objdata.intQuantity;
                    _objproduct.fl_weight = Convert.ToDouble(_objdata.dblWeight);
                    _objproduct.fl_length = Convert.ToDouble(_objdata.flLength);
                    _objproduct.fl_breadth = Convert.ToDouble(_objdata.flBreadth);
                    _objproduct.fl_height = Convert.ToDouble(_objdata.flHeight);
                    _objproduct.fl_GST = Convert.ToDouble(_objdata.flGST);
                    _objproduct.fl_QtyDiscount = _objdata.dblQtyDiscount;
                    _objproduct.int_BrandsId = _objdata.intBrands;
                    _objproduct.int_CategoryId = _objdata.intCategory;
                    _objproduct.v_image = _objdata.strImagePath;
                    _objproduct.v_description_info = _objdata.strDescription;
                    _objproduct.dt_created_on = DateTime.Now;
                    _objproduct.b_IsActive = true;
                    dataContext.tbl_Products.Add(_objproduct);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "Product save sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProductModal UpdateProduct(ProductModal _objdata)
        {
            tbl_Products _objproduct = new tbl_Products();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Products.Where(x => x.int_id == _objdata.intProductId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Products _log = new tbl_Products();

                        _log = dataContext.tbl_Products.Where(x => x.int_id == _objdata.intProductId).FirstOrDefault();
                        _log.v_name = _objdata.strProductName;
                        _log.fl_price = _objdata.dblPrice;
                        _log.int_quantity = _objdata.intQuantity;
                        _log.fl_weight = _objdata.dblWeight;
                        _log.fl_length = _objdata.flLength;
                        _log.fl_breadth = _objdata.flBreadth;
                        _log.fl_height = _objdata.flHeight;
                        _log.fl_GST = _objdata.flGST;
                        _log.fl_QtyDiscount = _objdata.dblQtyDiscount;
                        _log.int_BrandsId = _objdata.intBrands;
                        _log.int_CategoryId = _objdata.intCategory;
                        _log.v_image = _objdata.strProductName;
                        _log.v_description_info = _objdata.strDescription;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Product updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductBrands> GetBrands()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<ProductBrands> _listBrand = new List<ProductBrands>();
                dataContext.Database.Connection.Open();
                _listBrand = (from _brand in dataContext.tbl_Brands.AsEnumerable()
                              select new ProductBrands
                              {
                                  int_id = _brand.int_id,
                                  strBrands = _brand.v_name
                              }).ToList();
                _listBrand.Insert(0, new ProductBrands { strBrands = "--Select Brand--", int_id = 0 });
                return _listBrand;

            }
        }

        public List<ProductCategory> GetCategory()
        {
            using (newconecommerce dataContext = new newconecommerce())
            {
                List<ProductCategory> _listCategory = new List<ProductCategory>();
                dataContext.Database.Connection.Open();
                _listCategory = (from _category in dataContext.tbl_category.AsEnumerable()
                                 select new ProductCategory
                                 {
                                     int_id = _category.int_id,
                                     strCategory = _category.v_category
                                 }).ToList();
                _listCategory.Insert(0, new ProductCategory { strCategory = "--Select Category--", int_id = 0 });
                return _listCategory;

            }
        }

        public ProductModal GetProductById(ProductModal _productmodal)
        {
            ProductModal _objproduct = new ProductModal();
            using (newconecommerce dataContext = new newconecommerce())
            {
                _productmodal = (from x in dataContext.tbl_Products
                                 where x.int_id == _productmodal.intProductId
                                 select new ProductModal
                                 {
                                     strProductName = x.v_name,
                                     dblPrice = x.fl_price,
                                     dblWeight = x.fl_weight,
                                     strImagePath = x.v_image,
                                     intQuantity = x.int_quantity,
                                     flLength = x.fl_length,
                                     flBreadth = x.fl_breadth,
                                     flHeight = x.fl_height,
                                     flGST = x.fl_GST,
                                     dblQtyDiscount = x.fl_QtyDiscount,
                                     intBrands = x.int_BrandsId,
                                     intCategory = x.int_CategoryId,
                                     strDescription = x.v_description_info
                                 }).AsEnumerable().Select(x => new ProductModal
                                 {
                                     strProductName = x.strProductName,
                                     dblPrice = x.dblPrice,
                                     dblWeight = x.dblWeight,
                                     strImagePath = x.strImagePath,
                                     intQuantity = x.intQuantity,
                                     flLength = x.flLength,
                                     flBreadth = x.flBreadth,
                                     flHeight = x.flHeight,
                                     flGST = x.flGST,
                                     dblQtyDiscount = x.dblQtyDiscount,
                                     intBrands = x.intBrands,
                                     intCategory = x.intCategory,
                                     strDescription = x.strDescription
                                 }).FirstOrDefault();

                return _productmodal;
            }
        }
        public ProductModal DeleteProduct(int intProductId)
        {
            ProductModal _objdata = new ProductModal();
               tbl_Products _objproduct = new tbl_Products();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Products.Where(x => x.int_id == intProductId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Products _log = new tbl_Products();

                        _log = dataContext.tbl_Products.Where(x => x.int_id == intProductId).FirstOrDefault();
                        _log.b_IsActive = false;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Product updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
