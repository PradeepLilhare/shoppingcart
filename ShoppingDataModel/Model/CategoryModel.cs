using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{
    public class CategoryModel:ResponseModel
    {
        public int intCategoryId { get; set; }

        public string strCategoryName { get; set; }
    }
}
