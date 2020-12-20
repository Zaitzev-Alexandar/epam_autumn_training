using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorsLib;

namespace SheetsLib
{
    /// <summary>
    /// Abstract class describing film sheet
    /// </summary>
    public abstract class FilmSheet : Sheet
    {
        /// <summary>
        /// Constructor of FilmSheet class without color by default(colorless).
        /// </summary>
        public FilmSheet()
        {
            color = Color.Colorless;
        }
        /// <summary>
        /// Coloring sheet of film in a new color
        /// </summary>
        /// <param name="color">New color</param>
        public override void Coloring(Color color)
        {
            throw new Exception("Film sheet cannot be painted");
        }
    }
}
