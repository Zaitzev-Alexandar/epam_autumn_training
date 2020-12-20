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
    /// Class, describing film rectangle
    /// </summary>
    public class FilmRectangle : FilmSheet, IRectangle
    {
        /// <summary>
        /// Rectangle's length.
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// Rectangle's width.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Initializes class object  FilmCircle, which uses width and length.
        /// </summary>
        /// <param name="length"> Figure's length.</param>
        /// <param name="width">Figure's width.</param>
        public FilmRectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Returns figure's perimeter.
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return (Length + Width) * 2;
        }

        /// <summary>
        /// Returns figure's square.
        /// </summary>
        /// <returns></returns>
        public double GetSquare()
        {
            return Length * Width;
        }

        /// <summary>
        /// Initializes new class object FilmRectangle by cutting from another figure
        /// </summary>
        /// <param name="length">Figure's length.</param>
        /// <param name="width">Figure's width.</param>
        /// <param name="figure">Old figure</param>
        public FilmRectangle(double length, double width, IFigure figure)
        {
            if (GetType() != figure.GetType())
                throw new Exception("Figure material must be equal.");

            Length = length;
            Width = width;

            if (figure.GetSquare() < GetSquare())
                throw new Exception("New figure can't be bigger than old");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Figure: rectangle, material: film, ");
            stringBuilder.Append("square: ");
            stringBuilder.Append(GetSquare());
            stringBuilder.Append("perimeter: ");
            stringBuilder.Append(GetPerimeter());
            stringBuilder.Append(";\n");

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FilmRectangle rectangle &&
                   Length == rectangle.Length &&
                   Width == rectangle.Width;
        }

        public override int GetHashCode()
        {
            int hashCode = -1135836612;
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            return hashCode;
        }

    }
}
