using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsExceptionLib
{
    public class ProductNegativeCountException : Exception
    {
        public ProductNegativeCountException()
            : base("Count can't be negative.") { }
    }
}
