using ShoppingDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore
{
    public class DBDatacontext
    {
        private static newconecommerce dbContext = null;
        public static newconecommerce DataContext
        {
            get
            {
                if (dbContext != null)
                {
                    return dbContext;
                }
                else
                {
                    return dbContext = new newconecommerce();
                }

            }
        }
    }
}
