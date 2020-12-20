using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLib.Interfaces
{
    /// <summary>
    /// Interface describing circles
    /// </summary>
    public interface ICircle : IFigure
    {
        /// <summary>
        /// Property for getting circle diameter
        /// </summary>
        double Diameter { get; }
        /// <summary>
        /// Property for storaging circle radius
        /// </summary>
        double Radius { get; set; }
    }
}
