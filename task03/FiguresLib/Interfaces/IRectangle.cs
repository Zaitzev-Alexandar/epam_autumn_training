using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLib.Interfaces
{
    /// <summary>
    /// Interface describing rectangle
    /// </summary>
    public interface IRectangle : IFigure
    {
        /// <summary>
        /// Property for storaging length of rectangle
        /// </summary>
        double Length { get; set; }
        /// <summary>
        /// Property for storaging width of rectangle
        /// </summary>
        double Width { get; set; }
    }
}
