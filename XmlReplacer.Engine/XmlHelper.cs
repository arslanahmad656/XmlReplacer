using System.Xml;

namespace XmlReplacer.Engine;

static class XmlHelper
{
    public static void UpdateXmlAttributes(string rootPath, string elementName, string attributeName, string newValue, Action<Exception> onError)
    {
        foreach (var filePath in Directory.EnumerateFiles(rootPath, "*.xml", SearchOption.AllDirectories))
        {
            try
            {
                UpdateXmlFile(filePath, elementName, attributeName, newValue, onError);
            }
            catch (Exception ex)
            {
                onError(ex);
            }
        }
    }

    public static void UpdateXmlFile(string filePath, string elementName, string attributeName, string newValue, Action<Exception> onError)
    {
        try
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlNodeList elements = xmlDocument.GetElementsByTagName(elementName);

            foreach (XmlElement element in elements)
            {
                if (element.HasAttribute(attributeName))
                {
                    element.SetAttribute(attributeName, newValue);
                }
            }

            xmlDocument.Save(filePath);
        }
        catch (Exception ex)
        {
            onError(ex);
        }
    }
}
