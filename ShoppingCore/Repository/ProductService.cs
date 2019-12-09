using ShoppingDataAccess;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
    public class ProductService : IProductService
    {
        public object GetAllProductList()
        {
            try
            {
                List<ProductModalList> _listproductmodal = new List<ProductModalList>();
                using (newconecommerce dataContext = new newconecommerce())
                {
                    _listproductmodal = (from _product in dataContext.tbl_Products
                                         join _brand in dataContext.tbl_Brands on _product.int_BrandsId equals _brand.int_id
                                         join _category in dataContext.tbl_category on _product.int_CategoryId equals _category.int_id
                                         select new ProductModalList
                                         {
                                             intProductId = (int)_product.int_id,
                                             strProductName = _product.v_name,
                                             dblPrice = _product.fl_price,
                                             dblWeight = _product.fl_weight == null ? 0 : _product.fl_weight,
                                             strDescription = _product.v_description_info == null ? "" : _product.v_description_info,
                                             strImagePath = _product.v_image == null ? "" : "http://ecomportal.wittystacks.com/Content/Product/"+_product.v_image,
                                             intQuantity = (int)_product.int_quantity,
                                             flLength = _product.fl_length == null ? 0 : _product.fl_length,
                                             flBreadth = _product.fl_breadth == null ? 0 : _product.fl_breadth,
                                             flHeight = _product.fl_height == null ? 0 : _product.fl_height,
                                             flGST = _product.fl_GST == null ? 0 : _product.fl_GST,
                                             dblQtyDiscount = _product.int_quantity,
                                             intBrands = _product.int_BrandsId,
                                             strBrands = _brand.v_name,
                                             intCategory = _product.int_CategoryId,
                                             strCategory = _category.v_category
                                         }).ToList();

                    return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = _listproductmodal };

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
