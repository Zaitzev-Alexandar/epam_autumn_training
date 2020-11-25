using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using IngredientsLib;
using IngredientsLib.Ingredients;
using BakeryProdsLib;

namespace task01_UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        private readonly string filePath = Directory.GetCurrentDirectory() + @"\Files\Products.txt";

        [TestMethod]
        public void ReadFile()
        {
            BakeryProdsCollection collection = new BakeryProdsCollection(filePath);

            Assert.IsTrue(collection.Count == 5);
        }

        [DataTestMethod]
        [DataRow(SortState.Calorie, 150, 330)]
        [DataRow(SortState.Cost, 410, 630)]
        public void SortArray(SortState state, double min, double max)
        {
            BakeryProdsCollection collection = new BakeryProdsCollection(filePath);

            IBakeryProduct[] products = collection.GetSortedArray(state);

            double firstValue = 0;
            double secondValue = 0;
            switch (state)
            {
                case SortState.Calorie:
                    firstValue = products[0].GetCalorie();
                    secondValue = products[products.Length - 1].GetCalorie();
                    break;
                case SortState.Cost:
                    firstValue = products[0].GetCost();
                    secondValue = products[products.Length - 1].GetCost();
                    break;
            }

            Assert.IsTrue(firstValue == min && secondValue == max);
        }

        [DataTestMethod]
        [DataRow(330, 530)]
        public void GetProdcts_BakeryProduct(double calorie, double cost)
        {
            IBakeryProduct product = new Bread("test", new Flour(calorie, cost, 1));

            BakeryProdsCollection collection = new BakeryProdsCollection(filePath);
            IBakeryProduct[] products = collection.GetProducts(product);

            bool actual = true;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].GetCalorie() != calorie && products[i].GetCost() != cost)
                {
                    actual = false;
                    break;
                }
            }

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("Flour", 1)]
        [DataRow("Yeast", 1.5)]
        public void GetProdcts_Ingredient(string typeName, double value)
        {
            Ingredient ingredient = null;
            switch (typeName)
            {
                case "Flour":
                    ingredient = new Flour(1, 1, value);
                    break;
                case "Yeast":
                    ingredient = new Yeast(1, 1, value);
                    break;
            }

            BakeryProdsCollection collection = new BakeryProdsCollection(filePath);
            IBakeryProduct[] products = collection.GetProducts(ingredient);

            bool actual = true;
            for (int i = 0; i < products.Length; i++)
            {
                Ingredient[] ingredients = products[i].GetIngredients();
                for (int j = 0; j < ingredients.Length; j++)
                {
                    if (ingredients[j].GetType().Name == ingredient.GetType().Name)
                    {
                        if (!(ingredients[j].Value > value))
                        {
                            actual = false;
                            break;
                        }
                    }
                }
            }

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(1, 5)]
        [DataRow(2, 1)]
        public void GetProdcts_Count(int count, double actual)
        {
            BakeryProdsCollection collection = new BakeryProdsCollection(filePath);
            IBakeryProduct[] products = collection.GetProducts(count);

            Assert.IsTrue(products.Length == actual);
        }
    }
}
