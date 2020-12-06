using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsExceptionLib;

namespace ProductsLib
{
    /// <summary>
    /// Class product.
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// Name of a product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of a product. 
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Cost of a markup. 
        /// </summary>
        public double Markup { get; set; }

        /// <summary>
        /// Count of a product. 
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Inits a product.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Inits a product with parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        public Product(string name, double cost, double markup, int count)
        {
            Name = name;
            Cost = cost;
            Markup = markup;
            Count = count;
        }

        /// <summary>
        /// Returns unit cost.
        /// </summary>
        /// <returns></returns>
        public double GetUnitCost()
        {
            return Cost + Markup;
        }

        /// <summary>
        /// Returns total cost.
        /// </summary>
        /// <returns></returns>
        public double GetTotalCost()
        {
            return (Cost + Markup) * Count;
        }

        /// <summary>
        /// Operation plus for products.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Product operator +(Product left, Product right)
        {
            if (left.GetType() == right.GetType() && left.Name == right.Name)
            {
                double cost = (left.Cost * left.Count + right.Cost * right.Count) / (left.Count + right.Count);
                double markup = (left.Markup * left.Count + right.Markup * right.Count) / (left.Count + right.Count);
                int count = left.Count + right.Count;

                return GetProduct(left.GetType().Name, left.Name, cost, markup, count);
            }
            else
                throw new DifferentProductsException();
        }

        /// <summary>
        /// Decrease count of product by number.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Product operator -(Product left, int right)
        {
            if (left.Count > right)
            {
                int count = left.Count - right;
                return GetProduct(left.GetType().Name, left.Name, left.Cost, left.Markup, count);
            }
            else
                throw new ProductNegativeCountException();
        }

        /// <summary>
        /// Convert product to another product.
        /// </summary>
        /// <param name="inputProduct"></param>
        /// <param name="outputType"></param>
        /// <returns></returns>
        public static Product ConvertToAnotherType(Product inputProduct, Type outputType)
        {
            return GetProduct(outputType.Name, inputProduct.Name, inputProduct.Cost, inputProduct.Markup, inputProduct.Count);
        }

        /// <summary>
        /// Returns cost in kocpecks.
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(Product product)
        {
            return (int)product.GetTotalCost() * 100;
        }

        /// <summary>
        /// Returns cost.
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator double(Product product)
        {
            return product.GetTotalCost();
        }

        /// <summary>
        /// Returns product by type name.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="name"></param>
        /// <param name="cost"></param>
        /// <param name="markup"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static Product GetProduct(string typeName, string name, double cost, double markup, int count)
        {
            switch (typeName)
            {
                case nameof(Tool):
                    return new Tool(name, cost, markup, count);
                case nameof(Medicine):
                    return new Medicine(name, cost, markup, count);
                case nameof(Material):
                    return new Material(name, cost, markup, count);
                default:
                    return null;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Cost == product.Cost &&
                   Markup == product.Markup &&
                   Count == product.Count;
        }

        public override int GetHashCode()
        {
            int hashCode = 651863063;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Cost.GetHashCode();
            hashCode = hashCode * -1521134295 + Markup.GetHashCode();
            hashCode = hashCode * -1521134295 + Count.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: name={Name},cost={Cost},markup={Markup},count={Count},";
        }
    }
}
