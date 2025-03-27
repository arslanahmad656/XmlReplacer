using XmlReplacer.Engine;

string rootPath = args[0];
string elementName = args[1];
string attributeName = args[2];
string newValue = args[3];

if (string.IsNullOrEmpty(rootPath) || string.IsNullOrEmpty(elementName) ||
            string.IsNullOrEmpty(attributeName) || string.IsNullOrEmpty(newValue))
{
    Console.WriteLine("Please provide all required arguments: rootPath, elementName, attributeName, newValue.");
    return;
}

try
{
    var replacer = new Replacer(rootPath);
    replacer.SetAttributeValue(elementName, attributeName, newValue, ex =>
    {
        var color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Error detected: {ex.GetType().FullName}: {ex.Message}");
        Console.ForegroundColor = color;
    });
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}