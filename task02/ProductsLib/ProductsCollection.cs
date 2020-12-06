using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProductsLib
{
    public class ProductsCollection
    {
        private List<Product> _products;

        /// <summary>
        /// Inits products collection.
        /// </summary>
        public ProductsCollection()
        {
            _products = new List<Product>();
        }

        /// <summary>
        /// Inits collection with products.
        /// </summary>
        /// <param name="products"></param>
        public ProductsCollection(params Product[] products)
        {
            _products = products.ToList();
        }

        /// <summary>
        /// Returns products collection.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return _products;
        }

        /// <summary>
        /// Saves collection to json file.
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveToFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter writer = new JsonTextWriter(sw);
            writer.WriteStartArray();

            foreach (Product product in _products)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("type");
                writer.WriteValue(product.GetType().Name);

                writer.WritePropertyName("name");
                writer.WriteValue(product.Name);

                writer.WritePropertyName("cost");
                writer.WriteValue(product.Cost);

                writer.WritePropertyName("markup");
                writer.WriteValue(product.Markup);

                writer.WritePropertyName("count");
                writer.WriteValue(product.Count);

                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            File.WriteAllText(filePath, sb.ToString());
        }

        /// <summary>
        /// Gets collection from json file.
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                _products.Clear();

                string typeName = string.Empty;
                string name = string.Empty;
                double cost = 0;
                double markup = 0;
                int count = 0;

                StringReader sr = new StringReader(File.ReadAllText(filePath));
                JsonReader reader = new JsonTextReader(sr);

                while (reader.Read())
                {
                    var tokenType = reader.TokenType;
                    if (tokenType == JsonToken.PropertyName)
                    {
                        var value = (reader.Value as string) ?? string.Empty;

                        if (value == "type")
                            typeName = reader.ReadAsString();
                        if (value == "name")
                            name = reader.ReadAsString();
                        if (value == "cost")
                            cost = (double)reader.ReadAsDouble();
                        if (value == "markup")
                            markup = (double)reader.ReadAsDouble();
                        if (value == "count")
                            count = (int)reader.ReadAsInt32();
                    }

                    if (tokenType == JsonToken.EndObject)
                    {
                        _products.Add(Product.GetProduct(typeName, name, cost, markup, count));
                    }
                }
            }
        }
    }
}
