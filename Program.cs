using mslearn_dotnet_files;

try
{
    SalesService.GenerateTotalsReport();
    Console.WriteLine("Operation finished successfully.");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Error: the application does not have permission to access the file. {ex.Message}");
}