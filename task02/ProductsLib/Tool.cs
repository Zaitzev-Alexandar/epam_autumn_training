using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsLib
{
    /// <summary>
    /// Class Tool.
    /// </summary>
    public class Tool : Product
    {
        /// <summary>
        /// Inits Tool.
        /// </summary>
        public Tool() { }

        /// <summary>
        /// Inits Tool with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>

        public Tool(string name, double cost, double markup, int count)
            : base(name, cost, markup, count)
        { }
    }
}
