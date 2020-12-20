using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLib;


namespace SheetsLib
{
    /// <summary>
    /// Abstract class describing paper sheet
    /// </summary>
    public abstract class PaperSheet : Sheet
    {
        /// <summary>
        /// Constructor os PaperSheet class with white color by default
        /// </summary>
        public PaperSheet()
        {
            color = Color.White;
        }
        /// <summary>
        /// Coloring paper sheet in a new color
        /// </summary>
        /// <param name="color">New color</param>
        public override void Coloring(Color color)
        {
            if (IsColored == false)
            {
                this.color = color;
                IsColored = true;
            }
            else
            { throw new Exception("Paper sheet can colored only once"); }
        }
    }
}
