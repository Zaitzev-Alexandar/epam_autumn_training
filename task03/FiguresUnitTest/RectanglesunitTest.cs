using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiguresLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLib.PaperFigures;
using FiguresLib.FilmFigures;
using ColorsLib;

namespace FiguresUnitTest
{
    [TestClass]
    public class RectanglesUnitTest
    {
        [TestMethod]
        public void GetP_PaperRectangle()
        {
            int length = 10;
            int width = 10;
            double expected = 40;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            double actual = rectangle.GetPerimeter();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetP_FlimRectangle()
        {
            int length = 15;
            int width = 24;
            double expected = 78;

            FilmRectangle rectangle = new FilmRectangle(length, width);
            double actual = rectangle.GetPerimeter();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_PaperRectangle()
        {
            int length = 10;
            int width = 10;
            double expected = 100;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            double actual = rectangle.GetSquare();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_FlimRectangle()
        {
            int length = 15;
            int width = 24;
            double expected = 360;

            FilmRectangle rectangle = new FilmRectangle(length, width);
            double actual = rectangle.GetSquare();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeColor_PaperRectangle()
        {
            int length = 10;
            int width = 10;
            Color expected = Color.Purple;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            rectangle.Coloring(Color.Purple);
            Color actual = rectangle.GetColor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Film sheet cannot be painted")]
        public void ChangeColor_FlimRectangle_GetException()
        {
            int length = 15;
            int width = 24;

            FilmRectangle rectangle = new FilmRectangle(length, width);
            rectangle.Coloring(Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Paper sheet can colored only once")]
        public void ChangeColor_PaperRectangle_GetException()
        {
            int length = 10;
            int width = 10;

            PaperRectangle rectangle = new PaperRectangle(length, width);
            rectangle.Coloring(Color.Purple);
            rectangle.Coloring(Color.Black);
        }

        [TestMethod]
        public void CutFigure_FlimRectangle()
        {
            int length = 15;
            int width = 24;
            FilmRectangle rectangle = new FilmRectangle(20, 25);
            FilmRectangle expected = new FilmRectangle(15, 24);

            FilmRectangle actual = new FilmRectangle(length, width, rectangle);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "New figure can't be bigger than old")]
        public void CutFigure_FlimRectangle_GetException()
        {
            int length = 15;
            int width = 24;
            FilmRectangle rectangle = new FilmRectangle(10, 10);

            FilmRectangle actual = new FilmRectangle(length, width, rectangle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Figure materials must be equal.")]
        public void CutFigure_FlimRectangleFromPaper_GetException()
        {
            int length = 15;
            int width = 24;
            PaperRectangle rectangle = new PaperRectangle(10, 10);

            FilmRectangle actual = new FilmRectangle(length, width, rectangle);
        }
    }
}
