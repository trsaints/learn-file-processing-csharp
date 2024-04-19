using System.Globalization;
using mslearn_dotnet_files;
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesTotalDirectory = Path.Combine(currentDirectory, "salesTotalDir");

if (!Path.Exists(salesTotalDirectory))
    Directory.CreateDirectory(salesTotalDirectory);

var salesFiles = FindFiles(storesDirectory, "*.json", IsSalesFile);
ListFiles(salesFiles);

var jsonFiles = FindFiles(storesDirectory, "*", IsJson);
ListFiles(jsonFiles);

WriteFile([salesTotalDirectory, "sales.json"]);

var salesJson = ReadFile(["stores", "201", "sales.json"]);
var salesData = ReadJson(salesJson);
var totalString = salesData.Total.ToString(CultureInfo.CurrentCulture);

WriteFile([salesTotalDirectory, "totals.txt"], totalString);

Console.WriteLine(salesData.Total);

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
    var enumerable = files as string[] ?? files.ToArray();
    
    if (enumerable.Length == 0)
        return;

    foreach (var file in enumerable)
        Console.WriteLine(file);
    
    Console.WriteLine("\n");
}

void WriteFile(string[] path, string textContent = "")
{
    File.WriteAllText(Path.Combine(path), textContent);
}

string ReadFile(string[] path)
{
    return File.ReadAllText(Path.Combine(path));
}

SalesTotal ReadJson(string path)
{
    return JsonConvert.DeserializeObject<SalesTotal>(path) ?? throw new InvalidOperationException();
}