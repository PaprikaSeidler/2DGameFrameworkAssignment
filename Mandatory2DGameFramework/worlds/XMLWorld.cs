using Mandatory2DGameFramework.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.worlds
{
    public class XMLWorld
    {
        /// <summary>
        /// Gets the maximum X-coordinate value from XML.
        /// </summary>
        public int MaxX { get; private set; }
        /// <summary>
        /// Gets the maximum Y-coordinate value from XML.
        /// </summary>
        public int MaxY { get; private set; }
        /// <summary>
        /// Gets the difficulty level of the current context from XML.
        /// </summary>
        public string Difficulty { get; private set; }

        /// <summary>
        /// Reads world configuration from an XML file and initializes properties.
        /// If any required node is missing, logs an error and throws an exception.
        /// </summary>
        /// <param name="configFilePath">Your filepath</param>
        /// <exception cref="Exception"></exception>
        public XMLWorld(string configFilePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);

            XmlNode nodeX = doc.SelectSingleNode("/worldConfig/maxX");
            if (nodeX != null)
            {
                MaxX = int.Parse(nodeX.InnerText);
            }
            else
            {
                MyLogger.Instance.LogError("maxX node not found in XML configuration.");
                throw new Exception("maxX node not found in XML configuration.");
                
            }

            XmlNode nodeY = doc.SelectSingleNode("/worldConfig/maxY");
            if (nodeY != null)
            {
                MaxY = int.Parse(nodeY.InnerText);
            }
            else
            {
                MyLogger.Instance.LogError("maxY node not found in XML configuration.");
                throw new Exception("maxY node not found in XML configuration.");
            }

            XmlNode nodeDifficuly = doc.SelectSingleNode("/worldConfig/difficulty");
            if (nodeDifficuly != null)
            {
                Difficulty = nodeDifficuly.InnerText;
            }
            else
            {
                MyLogger.Instance.LogError("difficulty node not found in XML configuration.");
                throw new Exception("difficulty node not found in XML configuration.");
            }

        }
    }
}
