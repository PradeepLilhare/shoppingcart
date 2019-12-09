using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
   public class CategoryMasterBAL
    {
        CategoryMasterDataAccess _dataaccess = new CategoryMasterDataAccess();

        public List<CategoryModel> CategoryModelsList(List<CategoryModel> _listCategory)
        {
            return _dataaccess.CategoryMasterList(_listCategory);
        }
        public CategoryModel SaveCategory(CategoryModel _objproduct)
        {
            return _dataaccess.SaveCategory(_objproduct);
        }
        public CategoryModel UpdateCategory(CategoryModel _objCategory)
        {
            return _dataaccess.UpdateCategory(_objCategory);
        }
        public CategoryModel DeleteCategory(int intCategoryId)
        {
            return _dataaccess.DeleteCategory(intCategoryId);
        }
        public CategoryModel GetCategoryById(CategoryModel _Categorymodal)
        {
            return _dataaccess.GetCategoryById(_Categorymodal);
        }
    }
}
