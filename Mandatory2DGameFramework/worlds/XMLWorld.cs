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
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public string Difficulty { get; private set; }


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
