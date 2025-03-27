namespace XmlReplacer.Engine;

public class Replacer
{
    public Replacer(string rootPath, bool isRecursive)
    {
        if (!Path.Exists(rootPath))
        {
            throw new Exception($"{rootPath} does not exist.");
        }

        RootPath = rootPath;
        IsRecursive = isRecursive;
    }

    public string RootPath { get; }
    public bool IsRecursive { get; }

    public void SetAttributeValue(string elementName, string attributeName, string newValue, Action<Exception> onError) => XmlHelper.UpdateXmlAttributes(RootPath, elementName, attributeName, newValue, onError);
}
