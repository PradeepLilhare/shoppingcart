using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
    public class ProductMasterBAL
    {
        ProductMasterDataAccess _dataaccess = new ProductMasterDataAccess();

        public List<ProductMaster> ProductMastersList(List<ProductMaster> _listProduct)
        {
            return _dataaccess.ProductMastersList(_listProduct);
        }
        public ProductModal SaveProduct(ProductModal _objproduct)
        {
            return _dataaccess.SaveProduct(_objproduct);
        }
        public ProductModal UpdateProduct(ProductModal _objproduct)
        {
            return _dataaccess.UpdateProduct(_objproduct);
        }
        public ProductModal DeleteProduct(int intProductId)
        {
            return _dataaccess.DeleteProduct( intProductId);
        }
        public List<ProductBrands> GetBrands()
        {
            return _dataaccess.GetBrands();
        }
        public List<ProductCategory> GetCategory()
        {
            return _dataaccess.GetCategory();
        }
        public ProductModal GetProductById(ProductModal _productmodal)
        {
            return _dataaccess.GetProductById(_productmodal);
        }

    }
}
