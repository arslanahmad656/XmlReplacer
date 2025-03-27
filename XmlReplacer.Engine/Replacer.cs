namespace XmlReplacer.Engine;

public class Replacer
{
    public Replacer(string rootPath)
    {
        if (!Path.Exists(rootPath))
        {
            throw new Exception($"{rootPath} does not exist.");
        }

        RootPath = rootPath;
    }

    public string RootPath { get; }

    public void SetAttributeValue(string elementName, string attributeName, string newValue, Action<Exception> onError) => XmlHelper.UpdateXmlAttributes(RootPath, elementName, attributeName, newValue, onError);
}
