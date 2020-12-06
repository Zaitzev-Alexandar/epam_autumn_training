using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsLib
{
    /// <summary>
    /// Class Medicine.
    /// </summary>
    public class Medicine : Product
    {
        /// <summary>
        /// Inits Medicine.
        /// </summary>
        public Medicine() { }

        /// <summary>
        /// Inits Medicine with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        public Medicine(string name, double cost, double markup, int count)
            : base(name, cost, markup, count)
        { }
    }
}
