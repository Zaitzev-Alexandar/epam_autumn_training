using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLib;

namespace SheetsLib
{
    /// <summary>
    /// Abstract class describing plastic sheet
    /// </summary>
    public abstract class PlasticSheet : Sheet
    {
        /// <summary>
        /// Constructor os PlasticSheet class with white color by default
        /// </summary>
        public PlasticSheet()
        {
            color = Color.White;
            IsColored = false;
        }
        /// <summary>
        /// Coloring plastic sheet in a new color
        /// </summary>
        /// <param name="color">New color</param>
        public override void Coloring(Color color)
        {
            if(IsColored == false) { IsColored = true; }
            this.color = color;
            

        }
    }
}
