
namespace mslearn_dotnet_files;

public static class FileService
{
    public static IEnumerable<string> FindFiles(string path, string fileExtension, Func<string, bool> filter)
    {
        Console.WriteLine($"Searching for files in {path}...");
        var foundFiles = Directory.EnumerateFiles(path, fileExtension, SearchOption.AllDirectories);

        return foundFiles.Where(filter).ToList();
    }

    public static bool IsSalesFile(string file)
    {
        return file.EndsWith("sales.json");
    }



    public static void ListFiles(IEnumerable<string> files)
    {
        var enumerable = files as string[] ?? files.ToArray();
    
        if (enumerable.Length == 0)
            return;

        foreach (var file in enumerable)
            Console.WriteLine(file);
    
        Console.WriteLine("\n");
    }

    public static void WriteFile(string[] path, string textContent = "")
    {
        File.WriteAllText(Path.Combine(path), textContent);
    }

    public static string ReadFile(string[] path)
    {
        return File.ReadAllText(Path.Combine(path));
    }
}