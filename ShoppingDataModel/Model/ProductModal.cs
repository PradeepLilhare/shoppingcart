using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingDataModel.Model
{
    public class ProductModal : ResponseModel
    {
        public int? intProductId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Product name is Required.")]
        public string strProductName { get; set; }


        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [Required(ErrorMessage = "Selling price is Required.")]
        public double? dblPrice { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        //[Required(ErrorMessage = "Product weight is Required.")]
        public double? dblWeight { get; set; }

        [Required(ErrorMessage = "Description is Required.")]
        public string strDescription { get; set; }

        //[Required(ErrorMessage = "Product image is Required.")]
        public string strImagePath { get; set; }


        [RegularExpression("^[0-9]*$", ErrorMessage = "Product quantity must be numeric")]
        //[Required(ErrorMessage = "Product quantity is Required.")]
        public int? intQuantity { get; set; }


        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? flLength { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? flBreadth { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? flHeight { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? flGST { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? dblQtyDiscount { get; set; }

        [Required(ErrorMessage = "Product brand is Required.")]
        public int? intBrands { get; set; }

        [Required(ErrorMessage = "Product category is Required.")]
        public int? intCategory { get; set; }

        public string strBrands { get; set; }
        public List<ProductBrands> _listBrand;

        public List<ProductCategory> _listCategory;

        public string strCategory { get; set; }

        //   public HttpPostedFileBase File { get; set; }

    }
    public class ProductBrands
    {
        public int int_id { get; set; }

        public string strBrands { get; set; }
    }
    public class ProductCategory
    {
        public int int_id { get; set; }

        public string strCategory { get; set; }
    }
    public class ProductMaster
    {
        public int intProductId { get; set; }

        public string strBrand { get; set; }

        public string strCategory { get; set; }

        public string strProductName { get; set; }

        public int intStocks { get; set; }

        public double dblPrice { get; set; }
        public List<ProductMaster> _listProductMaster;
    }
    public class ProductModalList
    {
        public int intProductId { get; set; }

        public string strProductName { get; set; }

        public double? dblPrice { get; set; }

        public double? dblWeight { get; set; }

        public string strDescription { get; set; }

        public string strImagePath { get; set; }

        public int? intQuantity { get; set; }

        public double? flLength { get; set; }

        public double? flBreadth { get; set; }

        public double? flHeight { get; set; }

        public double? flGST { get; set; }

        public double? dblQtyDiscount { get; set; }

        public int? intBrands { get; set; }

        public int? intCategory { get; set; }

        public string strBrands { get; set; }

        public string strCategory { get; set; }
    }
}
