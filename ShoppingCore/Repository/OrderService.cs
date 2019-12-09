using ShoppingDataAccess;
using ShoppingDataModel.CommonUtility;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.Repository
{
    public class OrderService : IOrderService
    {
        private newconecommerce dataContext = DBDatacontext.DataContext;

        public object AddToCart(AddToCartModel addtocart)
        {
            try
            {
                using (newconecommerce dataContext = new newconecommerce())
                {
                    if (addtocart.int_user_id == 0)
                    {
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = CCommon.StatusCode.Fail.ToString(), data = "Incorrect Retailer Id." };
                    }                   
                    else

                    {
                        MemoryStream memStream = new MemoryStream();
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(memStream, addtocart.listProduct);
                        byte[] arrBytes = memStream.ToArray();
                        memStream.Write(arrBytes, 0, arrBytes.Length);
                        memStream.Seek(0, SeekOrigin.Begin);
                       test(memStream.GetBuffer());
                        dataContext.usp_insert_shopping_cart(addtocart.int_user_id, memStream.GetBuffer());

                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = "Successfully Added to Cart" };
                    }
                }
            }
            catch (Exception ex)
            {

                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = "Failed to AddToCart." };
            }
        }


        public object getProductCartByUserId(AddToCartModel addtocart)
        {
            try
            {

                using (newconecommerce dataContext = new newconecommerce())
                {
                    if (addtocart.int_user_id == 0)
                    {
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = CCommon.StatusCode.Fail.ToString(), data = "Incorrect Retailer Id." };
                    }
                    else

                    {
                        var result = dataContext.usp_get_user_cart_by_id(addtocart.int_user_id).ToList();
                        if (result.Count > 0)
                        {
                            if (result[0] != null)
                            {
                                MemoryStream memStream = new MemoryStream();
                                BinaryFormatter formatter = new BinaryFormatter();
                                memStream.Position = 0;
                                memStream = new MemoryStream();

                                byte[] strTemp = (byte[])result[0];

                                memStream.Write(strTemp, 0, strTemp.Length);
                                memStream.Seek(0, SeekOrigin.Begin);
                                Object obj = (Object)formatter.Deserialize(memStream);
                                addtocart.listProduct = (List<Product>)obj;
                                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Success, StatusMessaage = CCommon.StatusCode.Success.ToString(), data = addtocart };
                            }
                        }
                        return new ResponseModel { StatusCode = (int)CCommon.StatusCode.Fail, StatusMessaage = CCommon.StatusCode.Fail.ToString(), data = "No data Found." };
                    }
                }
            }
            catch (Exception ex)
            {
                CMail.SendSystemGeneratedMailSync(CCommon.strAdminEmailID, "TRACKING-ERROR-MAIL", ex.ToString(), CCommon.strEmailFrom, true);
                return new ResponseModel { StatusCode = (int)CCommon.StatusCode.ExceptionOccured, StatusMessaage = CCommon.StatusCode.ExceptionOccured.ToString(), data = "Failed to AddToCart." };
            }
        }

        public void test(byte[] ase)
        {
            MemoryStream memStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            memStream = new MemoryStream();

            byte[] strTemp = (byte[])ase;

            memStream.Write(strTemp, 0, strTemp.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)formatter.Deserialize(memStream);
            var sb = (List<Product>)obj;
        }
    }
}
