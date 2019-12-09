using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
   public class AddToCartModel
    {
        public int int_user_id { get; set; }     
        public List<Product> listProduct { get; set; }
    }
    [DataContract]
    [Serializable]
    public class Product
    {
        [DataMember]
        public int intProductId { get; set; }
        [DataMember]
        public int intQuantity { get; set; }
        [DataMember]
        public int intColorId { get; set; }
    }  
}
