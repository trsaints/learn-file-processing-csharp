using System.Globalization;
using mslearn_dotnet_files;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesTotalDirectory = Path.Combine(currentDirectory, "salesTotalDir");

if (!Path.Exists(salesTotalDirectory))
    Directory.CreateDirectory(salesTotalDirectory);

var salesFiles = FileService.FindFiles(storesDirectory, "*.json", FileService.IsSalesFile);
FileService.ListFiles(salesFiles);

var jsonFiles = FileService.FindFiles(storesDirectory, "*", JsonService.IsJson);
FileService.ListFiles(jsonFiles);

FileService.WriteFile([salesTotalDirectory, "sales.json"]);

var salesJson = FileService.ReadFile(["stores", "201", "sales.json"]);
var salesData = JsonService.ReadJson(salesJson);
var totalString = salesData.Total.ToString(CultureInfo.CurrentCulture);

FileService.WriteFile([salesTotalDirectory, "totals.txt"], totalString);

Console.WriteLine(salesData.Total);
