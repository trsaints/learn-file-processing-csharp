var currentDirectory = Directory.GetCurrentDirectory();

var salesFiles = FindFiles(currentDirectory, "*.json", IsSalesFile);

listFiles(salesFiles);

var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

salesFiles = FindFiles(documentsFolder, "*.json", IsSalesFile);

listFiles(salesFiles);

var customPath = Path.Combine("/home", "trsaints", "RiderProjects", "mslearn-dotnet-files", "stores");

salesFiles = FindFiles(customPath, "*.json", IsSalesFile);

listFiles(salesFiles);

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

void listFiles(IEnumerable<string> files)
{
    if (files.Count() == 0)
    {
        Console.WriteLine("No sales files found.");
        return;
    }

    foreach (var file in files)
        Console.WriteLine(file);
}
