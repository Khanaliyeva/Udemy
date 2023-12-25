using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Business.Exceptions.Category
{
    public class categoryNullException:Exception
    {
        public categoryNullException():base("Category null olmaz") {}
    }
}
