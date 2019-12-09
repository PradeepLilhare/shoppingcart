using ShoppingDataAccess;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.ShoppingWebRepository
{
    public class BrandMasterDataAccess
    {
        public List<BrandModel> BrandMastersList(List<BrandModel> _listBrand)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {

                    List<BrandModel> _list = (from _Brand in dataContext.tbl_Brands
                                                  // where _Brand.b_IsActive == true
                                              select new BrandModel
                                              {
                                                  intBrandId = _Brand.int_id,
                                                  strBrandName = _Brand.v_name
                                              }).ToList();
                    return _list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BrandModel SaveBrand(BrandModel _objdata)
        {
            tbl_Brands _objBrand = new tbl_Brands();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    _objBrand.v_name = _objdata.strBrandName;
                    dataContext.tbl_Brands.Add(_objBrand);
                    dataContext.SaveChanges();
                    dataContext.Database.Connection.Close();
                    _objdata.StatusMessaage = "Brand save sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public BrandModel UpdateBrand(BrandModel _objdata)
        {
            tbl_Brands _objBrand = new tbl_Brands();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Brands.Where(x => x.int_id == _objdata.intBrandId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Brands _log = new tbl_Brands();

                        _log = dataContext.tbl_Brands.Where(x => x.int_id == _objdata.intBrandId).FirstOrDefault();
                        _log.v_name = _objdata.strBrandName;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Brand updated sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public BrandModel GetBrandById(BrandModel _Brandmodal)
        {
            BrandModel _objBrand = new BrandModel();
            using (newconecommerce dataContext = new newconecommerce())
            {
                _objBrand = (from x in dataContext.tbl_Brands
                             where x.int_id == _Brandmodal.intBrandId
                             select new BrandModel
                             {
                                 strBrandName = x.v_name
                             }).AsEnumerable().Select(x => new BrandModel
                             {
                                 strBrandName = x.strBrandName
                             }).FirstOrDefault();

                return _objBrand;
            }
        }

        public BrandModel DeleteBrand(int intBrandId)
        {
            BrandModel _objdata = new BrandModel();
            tbl_Brands _objBrand = new tbl_Brands();
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    dataContext.Database.Connection.Open();
                    var _query = dataContext.tbl_Brands.Where(x => x.int_id == intBrandId).FirstOrDefault();
                    if (_query != null)
                    {
                        tbl_Brands _log = new tbl_Brands();

                        _log = dataContext.tbl_Brands.Where(x => x.int_id == intBrandId).FirstOrDefault();
                      // _log.b_IsActive = false;

                        dataContext.SaveChanges();
                        dataContext.Database.Connection.Close();
                    }
                    _objdata.StatusMessaage = "Brand deleted sucessfully.";
                    return _objdata;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
