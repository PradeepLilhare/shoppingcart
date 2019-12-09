using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class CategoryMasterDataAccess
    {
        public List<CategoryModel>CategoryMasterList(List<CategoryModel> _listCategory)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<CategoryModel> _list = (from _category in dataContext.tbl_category
                                                 where _category.b_IsActive == true
                                                 select new CategoryModel
                                                 {
                                                     intCategoryId = _category.int_id,
                                                     strCategoryName = _category.v_category
                                                 }).ToList();
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CategoryModel SaveCategory(CategoryModel _objdata)
        {
            tbl_category _objCategory = new tbl_category();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    _objCategory.v_category = _objdata.strCategoryName;
                    _objCategory.b_IsActive = true;
                    dataContext.tbl_category.Add(_objCategory);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "Category save sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryModel UpdateCategory(CategoryModel _objdata)
        {
            tbl_category _objcategory = new tbl_category();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_category.Where(x => x.int_id == _objdata.intCategoryId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_category _log = new tbl_category();

                        _log = dataContext.tbl_category.Where(x => x.int_id == _objdata.intCategoryId).FirstOrDefault();
                        _log.v_category = _objdata.strCategoryName;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Category updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryModel GetCategoryById(CategoryModel _categorymodal)
        {
            CategoryModel _objcategory = new CategoryModel();
            using (newconecommerce dataContext = new newconecommerce())
            {
                _objcategory = (from x in dataContext.tbl_category
                                where x.int_id == _categorymodal.intCategoryId
                                select new CategoryModel
                                {
                                    strCategoryName = x.v_category
                                }).AsEnumerable().Select(x => new CategoryModel
                                {
                                    strCategoryName = x.strCategoryName
                                }).FirstOrDefault();

                return _objcategory;
            }
        }

        public CategoryModel DeleteCategory(int intCategoryId)
        {
            CategoryModel _objdata = new CategoryModel();
            tbl_category _objcategory = new tbl_category();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_category.Where(x => x.int_id == intCategoryId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_category _log = new tbl_category();

                        _log = dataContext.tbl_category.Where(x => x.int_id == intCategoryId).FirstOrDefault();
                        _log.b_IsActive = false;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Category updated sucessfully.";
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
