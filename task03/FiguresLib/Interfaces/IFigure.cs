using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLib.Interfaces
{
    /// <summary>
    /// Interface describing figures
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Method for calculating square of figure
        /// </summary>
        /// <returns></returns>
        double GetSquare();
        /// <summary>
        /// Method for calculating perimeter of figure
        /// </summary>
        /// <returns></returns>
        double GetPerimeter();
    }
}
