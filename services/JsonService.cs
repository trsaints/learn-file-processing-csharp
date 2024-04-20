namespace mslearn_dotnet_files.services;
using models;
using Newtonsoft.Json;

public static class JsonService
{
    public static SalesTotal ReadJson(string path)
    {
        return JsonConvert.DeserializeObject<SalesTotal>(path) ?? throw new InvalidOperationException();
    }

    public static bool IsJson(string file)
    {
        var fileExtension = Path.GetExtension(file);
    
        return fileExtension == ".json";
    }
}