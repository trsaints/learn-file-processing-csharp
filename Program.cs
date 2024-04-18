var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesFiles = FindFiles(storesDirectory, "*.json", IsSalesFile);
ListFiles(salesFiles);

var jsonFiles = FindFiles(storesDirectory, "*", IsJson);
ListFiles(jsonFiles);

return;

IEnumerable<string> FindFiles(string path, string fileExtension, Func<string, bool> filter)
{
    Console.WriteLine($"Searching for files in {path}...");
    var foundFiles = Directory.EnumerateFiles(path, fileExtension, SearchOption.AllDirectories);

    return foundFiles.Where(filter).ToList();
}

bool IsSalesFile(string file)
{
    return file.EndsWith("sales.json");
}

bool IsJson(string file)
{
    var fileExtension = Path.GetExtension(file);
    
    return fileExtension == ".json";
}

void ListFiles(IEnumerable<string> files)
{
    if (files.Count() == 0)
    {
        Console.WriteLine("No sales files found.");
        return;
    }

    foreach (var file in files)
        Console.WriteLine(file);
    
    Console.WriteLine("\n");
}
