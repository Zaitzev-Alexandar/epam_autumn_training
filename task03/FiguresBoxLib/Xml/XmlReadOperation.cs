using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using FiguresLib.PaperFigures;
using FiguresLib.FilmFigures;
using FiguresLib.PlasticFigures;
using FiguresLib.Interfaces;

namespace FiguresBoxLib.Xml
{
    /// <summary>
    /// Method enumerations for reading xml files.
    /// </summary>
    public enum XmlReadType
    {
        /// <summary>
        /// StreamReader.
        /// </summary>
        StreamReader,
        /// <summary>
        /// XmlReader.
        /// </summary>
        XmlReader
    }
    /// <summary>
    /// Class describing reading xml file.
    /// </summary>
    internal class XmlReadOperation
    {
        /// <summary>
        /// Reading figures from xml file using StreamReader.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <returns></returns>
        public IFigure[] ReadXmlWithStreamReader(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string xmlString = reader.ReadToEnd();

                XmlDocument document = new XmlDocument();
                document.LoadXml(xmlString);

                XmlNodeList list = document.GetElementsByTagName("figure");

                IFigure[] figures = InitFiguresArray();

                // Fill array with figures.
                int index = 0;
                foreach (XmlNode node in list)
                {
                    if (index != figures.Length)
                    {
                        figures[index] = GetFigure(node);
                        index++;
                    }
                    else
                    {
                        return figures;
                    }
                }

                return figures;
            }
        }

        /// <summary>
        /// Reading figures from xml file using XmlReader.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <returns></returns>
        public IFigure[] ReadXmlWithXmlReader(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                IFigure[] figures = InitFiguresArray();
                int index = 0;

                string element = "";

                string material = "";
                string form = "";

                int length = 0;
                int width = 0;
                int radius = 0;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        element = reader.Name;
                        if (element == "figure")
                        {
                            material = reader.GetAttribute("material");
                            form = reader.GetAttribute("form");
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "length":
                                length = int.Parse(reader.Value);
                                break;
                            case "width":
                                width = int.Parse(reader.Value);
                                break;
                            case "radius":
                                radius = int.Parse(reader.Value);
                                break;
                        }
                    }
                    else if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "figure"))
                    {
                        if (index != figures.Length)
                        {
                            figures[index] = GetConcreteSheetFigure(material, form, length, width, radius);
                            index++;
                        }
                        else
                        {
                            return figures;
                        }
                    }
                }

                return figures;
            }
        }

        /// <summary>
        /// Initialize array of figures.
        /// </summary>
        private IFigure[] InitFiguresArray()
        {
            IFigure[] figures = new IFigure[20];

            for (int i = 0; i < figures.Length; i++)
                figures[i] = null;

            return figures;
        }

        /// <summary>
        /// Returns figure from xml file.
        /// </summary>
        /// <param name="figure">Figure in xml.</param>
        /// <returns></returns>
        private IFigure GetFigure(XmlNode figure)
        {
            GetFigureSideValues(figure, out int length, out int width, out int radius);
            GetFigureMaterialAndForm(figure, out string material, out string form);
            return GetConcreteSheetFigure(material, form, length, width, radius);
        }

        /// <summary>
        /// Returns sides of figure.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <param name="length">Length.</param>
        /// <param name="width">Width.</param>
        /// <param name="radius">Radius.</param>
        private void GetFigureSideValues(XmlNode figure, out int length, out int width, out int radius)
        {
            length = 0;
            width = 0;
            radius = 0;

            XmlNodeList sides = figure.ChildNodes;
            foreach (XmlNode side in sides)
            {
                switch (side.Name)
                {
                    case "length":
                        length = int.Parse(side.InnerText);
                        break;
                    case "width":
                        width = int.Parse(side.InnerText);
                        break;
                    case "radius":
                        radius = int.Parse(side.InnerText);
                        break;
                }
            }

            if (length == 0 && width == 0 && radius == 0)
                throw new Exception("Incorrect values of figure's sides");
        }

        /// <summary>
        /// Return material and form of figure
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <param name="material">Material.</param>
        /// <param name="form">Form.</param>
        private void GetFigureMaterialAndForm(XmlNode figure, out string material, out string form)
        {
            material = "";
            form = "";

            foreach (XmlAttribute attribute in figure.Attributes)
            {
                switch (attribute.Name)
                {
                    case "material":
                        material = attribute.InnerText;
                        break;
                    case "form":
                        form = attribute.InnerText;
                        break;
                }
            }

            if (material == "" || form == "")
                throw new Exception("Incorrect values of figure's material and sides");
        }

        /// <summary>
        /// Return figure with specific material and form
        /// </summary>
        /// <param name="material">Figure's material.</param>
        /// <param name="form">Figure's form.</param>
        /// <param name="length">Figure's length.</param>
        /// <param name="width">Figure's width.</param>
        /// <param name="radius">Figure's radius.</param>
        /// <returns></returns>
        private IFigure GetConcreteSheetFigure(string material, string form, int length, int width, int radius)
        {
            IFigure figure = null;

            if (material == "Paper")
            {
                if (form == "Rectangle")
                    figure = new PaperRectangle(length, width);
                if (form == "Circle")
                    figure = new PaperCircle(radius);
            }

            if (material == "Film")
            {
                if (form == "Rectangle")
                    figure = new FilmRectangle(length, width);
                if (form == "Circle")
                    figure = new FilmCircle(radius);
            }
            if (material == "Plastic")
            {
                if (form == "Rectangle")
                    figure = new PlasticRectangle(length, width);
                if (form == "Circle")
                    figure = new PlasticCircle(radius);
            }


            if (figure == null)
                throw new Exception("Incorrect data for figure");
            else
                return figure;
        }
    }
}
