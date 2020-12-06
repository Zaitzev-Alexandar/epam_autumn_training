using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsExceptionLib
{
    public class DifferentProductsException : Exception
    {
        public DifferentProductsException()
            : base("Operation error, different types .") { }
    }
}
