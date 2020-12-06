using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsLib;
using ProductsExceptionLib;

namespace ProductsTestProject
{
    [TestClass]
    public class UnitTests
    {
        readonly string filePath = Directory.GetCurrentDirectory() + @"\file.json";

        [DataTestMethod]
        [DataRow(100, 10, 110)]
        [DataRow(200, 20, 220)]
        [DataRow(300, 30, 330)]
        public void GetUnitCost(double cost, double markup, double expected)
        {
            Tool tool = new Tool
            {
                Cost = cost,
                Markup = markup
            };

            double actual = tool.GetUnitCost();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, 10, 1, 110)]
        [DataRow(200, 20, 2, 440)]
        [DataRow(300, 30, 3, 990)]
        public void GetTotalCost(double cost, double markup, int count, double expected)
        {
            Tool tool = new Tool
            {
                Cost = cost,
                Markup = markup,
                Count = count
            };

            double actual = tool.GetTotalCost();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SaveToFIle()
        {
            Tool tool = new Tool("tool1", 10, 11, 2);
            Material material = new Material("material1", 12, 13, 3);
            Medicine medicine = new Medicine("medicine1", 13, 14, 4);

            ProductsCollection collection = new ProductsCollection(tool, material, medicine);
            collection.SaveToFile(filePath);

            Assert.IsTrue(File.ReadAllText(filePath).Length > 0);
        }

        [TestMethod]
        public void ReadFIle()
        {
            Tool tool = new Tool("tool1", 10, 11, 2);
            Material material = new Material("material1", 12, 13, 3);
            Medicine medicine = new Medicine("medicine1", 13, 14, 4);
            ProductsCollection expectedCollection = new ProductsCollection(tool, material, medicine);
            List<Product> expected = expectedCollection.GetProducts();

            ProductsCollection actualCollection = new ProductsCollection();
            actualCollection.ReadFile(Directory.GetCurrentDirectory() + @"\file.json");
            List<Product> actual = actualCollection.GetProducts();

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, 20, 10, 200, 10, 15)]
        [DataRow(110, 21, 11, 201, 10, 15)]
        [DataRow(120, 22, 13, 204, 17, 11)]
        public void Plus_Tools(double leftCost, double leftMarkup, int leftCount, int rightCost, double rightMarkup, int rightCount)
        {
            double cost = (leftCost * leftCount + rightCost * rightCount) / (leftCount + rightCount);
            double markup = (leftMarkup * leftCount + rightMarkup * rightCount) / (leftCount + rightCount);
            int count = leftCount + rightCount;
            Tool expected = new Tool("tool", cost, markup, count);

            Tool leftTool = new Tool("tool", leftCost, leftMarkup, leftCount);
            Tool rightTool = new Tool("tool", rightCost, rightMarkup, rightCount);
            Product actual = leftTool + rightTool;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(23, 12, 11)]
        [DataRow(54, 2, 52)]
        [DataRow(4, 3, 1)]
        public void Minus_Materials(int leftCount, int rightCount, int expected)
        {
            Material material = new Material("material", 1, 1, leftCount);

            Product actual = material - rightCount;

            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod()]
        [DataRow(100, 20, 10, 200, 10, 15)]
        [DataRow(110, 21, 11, 201, 10, 15)]
        [DataRow(120, 22, 13, 204, 17, 11)]
        [ExpectedException(typeof(DifferentProductsException))]
        public void Plus_GetException(double leftCost, double leftMarkup, int leftCount, int rightCost, double rightMarkup, int rightCount)
        {
            double cost = (leftCost * leftCount + rightCost * rightCount) / (leftCount + rightCount);
            double markup = (leftMarkup * leftCount + rightMarkup * rightCount) / (leftCount + rightCount);
            int count = leftCount + rightCount;
            Tool expected = new Tool("tool", cost, markup, count);

            Tool leftTool = new Tool("tool", leftCost, leftMarkup, leftCount);
            Material material = new Material("material", rightCost, rightMarkup, rightCount);
            Product actual = leftTool + material;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(23, 25, 11)]
        [DataRow(54, 100, 52)]
        [DataRow(4, 7, 1)]
        [ExpectedException(typeof(ProductNegativeCountException))]
        public void Minus_GetException(int leftCount, int rightCount, int expected)
        {
            Material material = new Material("material", 1, 1, leftCount);

            Product actual = material - rightCount;

            Assert.AreEqual(expected, actual.Count);
        }

        [DataTestMethod]
        [DataRow(100, 10, 1, 11000)]
        [DataRow(200, 20, 2, 44000)]
        [DataRow(300, 30, 3, 99000)]
        public void ConvertToInt(double cost, double markup, int count, double expected)
        {
            Tool tool = new Tool
            {
                Cost = cost,
                Markup = markup,
                Count = count
            };

            int actual = (int)tool;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, 10, 1, 110)]
        [DataRow(200, 20, 2, 440)]
        [DataRow(300, 30, 3, 990)]
        public void ConvertToDouble(double cost, double markup, int count, double expected)
        {
            Tool tool = new Tool
            {
                Cost = cost,
                Markup = markup,
                Count = count
            };

            double actual = (double)tool;

            Assert.AreEqual(expected, actual);
        }
    }
}
