using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLib.PaperFigures;
using FiguresLib.FilmFigures;
using ColorsLib;

namespace FiguresUnitTest
{
    [TestClass]
    public class CirclesUnitTest
    {
        [TestMethod]
        public void GetP_PaperCircle()
        {
            int radius = 10;
            double expected = 2 * Math.PI * radius;

            PaperCircle rectangle = new PaperCircle(radius);
            double actual = rectangle.GetPerimeter();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetP_FilmCircle()
        {
            int radius = 15;
            double expected = 2 * Math.PI * radius;

            FilmCircle rectangle = new FilmCircle(radius);
            double actual = rectangle.GetPerimeter();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_PaperCircle()
        {
            int radius = 10;
            double expected = Math.PI * radius * radius;

            PaperCircle rectangle = new PaperCircle(radius);
            double actual = rectangle.GetSquare();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetS_FilmCircle()
        {
            int radius = 15;
            double expected = Math.PI * radius * radius;

            FilmCircle rectangle = new FilmCircle(radius);
            double actual = rectangle.GetSquare();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Coloring_PaperCircle()
        {
            int radius = 10;
            Color expected = Color.Purple;

            PaperCircle rectangle = new PaperCircle(radius);
            rectangle.Coloring(Color.Purple);
            Color actual = rectangle.GetColor;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Film sheet cannot be painted")]
        public void Coloring_FilmCircle_GetException()
        {
            int radius = 15;

            FilmCircle rectangle = new FilmCircle(radius);
            rectangle.Coloring(Color.Black);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Paper sheet can colored only once")]
        public void Coloring_PaperCircle_GetException()
        {
            int radius = 10;

            PaperCircle rectangle = new PaperCircle(radius);
            rectangle.Coloring(Color.Purple);
            rectangle.Coloring(Color.Black);
        }

        [TestMethod]
        public void CutFigure_FilmCircle()
        {
            int radius = 15;
            FilmCircle circle = new FilmCircle(16);

            FilmCircle actual = new FilmCircle(radius, circle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "New figure can't be bigger than old")]
        public void CutFigure_FilmCircle_GetException()
        {
            int radius = 15;
            FilmCircle circle = new FilmCircle(14);

            FilmCircle actual = new FilmCircle(radius, circle);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Figure materials must be equal.")]
        public void CutFigure_FilmCircleFromPaper_GetException()
        {
            int radius = 15;
            PaperCircle circle = new PaperCircle(16);

            FilmCircle actual = new FilmCircle(radius, circle);
        }
    }
}
