using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
   public class BrandMasterBAL
    {
        BrandMasterDataAccess _dataaccess = new BrandMasterDataAccess();

        public List<BrandModel> BrandModelsList(List<BrandModel> _listBrand)
        {
            return _dataaccess.BrandMastersList(_listBrand);
        }
        public BrandModel SaveBrand(BrandModel _objproduct)
        {
            return _dataaccess.SaveBrand(_objproduct);
        }
        public BrandModel UpdateBrand(BrandModel _objBrand)
        {
            return _dataaccess.UpdateBrand(_objBrand);
        }
        public BrandModel DeleteBrand(int intBrandId)
        {
            return _dataaccess.DeleteBrand(intBrandId);
        }       
        public BrandModel GetBrandById(BrandModel _brandmodal)
        {
            return _dataaccess.GetBrandById(_brandmodal);
        }
    }
}
