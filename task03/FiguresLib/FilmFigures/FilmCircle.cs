using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLib.Interfaces;
using SheetsLib;

namespace FiguresLib.FilmFigures
{
    /// <summary>
    /// Class, describing film circle
    /// </summary>
    public class FilmCircle : FilmSheet, ICircle
    {
        /// <summary>
        /// Diameter.
        /// </summary>
        public double Diameter { get; set; }
        /// <summary>
        /// Radius.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Initializes class object  FilmCircle, which uses radius.
        /// </summary>
        /// <param name="radius">Figure's radius.</param>
        public FilmCircle(double radius)
        {
            Radius = radius;
            Diameter = 2 * radius;
        }

        /// <summary>
        /// Returns circle's perimeter.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Returns circle's square.
        /// </summary>
        /// <returns></returns>
        public double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Initializes new class object FilmCircle by cutting from another figure
        /// </summary>
        /// <param name="radius">Figure radius</param>
        /// <param name="figure">Old figure</param>
        public FilmCircle(int radius, IFigure figure)
        {
            if (GetType() != figure.GetType())
                throw new Exception("Figure material must be equal.");

            Radius = radius;
            Diameter = 2 * Radius;

            if (figure.GetSquare() < GetSquare())
                throw new Exception("New figure can't be bigger than old");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Figure: circle, mareial: film, ");
            stringBuilder.Append("square: ");
            stringBuilder.Append(GetSquare());
            stringBuilder.Append("perimeter: ");
            stringBuilder.Append(GetPerimeter());
            stringBuilder.Append(";\n");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FilmCircle circle &&
                   Diameter == circle.Diameter &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            int hashCode = 2056850621;
            hashCode = hashCode * -1521134295 + Diameter.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }
    }
}
