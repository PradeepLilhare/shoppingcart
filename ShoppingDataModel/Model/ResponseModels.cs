using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDataModel.Model
{

    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusMessaage { get; set; }
        public dynamic data { get; set; }
    }
}

