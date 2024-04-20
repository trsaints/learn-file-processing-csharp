namespace mslearn_dotnet_files.services;

public static class SalesService
{
    private static double CalculateTotals(IEnumerable<string> salesFiles)
    {
        double salesTotal = 0;
        
        foreach (var file in salesFiles)
        {
            var salesJson = FileService.ReadFile([file]);

            var data = JsonService.ReadJson(salesJson);
            
            salesTotal += data?.Total ?? 0;
        }

        return salesTotal;
    }

    public static void GenerateTotalsReport()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var storesDirectory = Path.Combine(currentDirectory, "stores");
        var salesTotalDirectory = Path.Combine(currentDirectory, "salesTotalDir");

        if (!Path.Exists(salesTotalDirectory))
            Directory.CreateDirectory(salesTotalDirectory);

        var salesFiles = FileService.FindFiles(storesDirectory, "*.json", FileService.IsSalesFile);

        var salesTotal = CalculateTotals(salesFiles);

        FileService.AppendTo([salesTotalDirectory, "totals.txt"], $"{salesTotal}{Environment.NewLine}");
    }
}