var salesFiles = FindFiles("/home/trsaints/RiderProjects/mslearn-dotnet-files/stores/", "*.json", IsSalesFile);


foreach (var file in salesFiles)
    Console.WriteLine(file);
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

