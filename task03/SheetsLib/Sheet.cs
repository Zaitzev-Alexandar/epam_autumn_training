using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLib;
using FiguresLib;


namespace SheetsLib
{
    /// <summary>
    /// Abstract class describing sheet of any material
    /// </summary>
    public abstract class Sheet
    {
        /// <summary>
        /// Variable for storaging color of material
        /// </summary>
        protected Color color;
        /// <summary>
        /// Property for geting color value
        /// </summary>
        public Color GetColor { get { return color; } }
        /// <summary>
        /// Contains information about coloring a sheet of material
        /// </summary>
        public bool IsColored { get; protected set; }
        /// <summary>
        /// Class constructor
        /// </summary>
        public Sheet()
        {
            IsColored = false;
        }
        /// <summary>
        /// Coloring sheet of material
        /// </summary>
        /// <param name="color">New color</param>
        public abstract void Coloring(Color color);
    }
}
