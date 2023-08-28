using CsvHelper;
using StockManagement.Application.Contracts.Infrastructure;
using StockManagement.Application.Features.Products.Queries.GetProductsExport;

namespace StockManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportProductsToCsv(List<ProductExportDto> productExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using(var streamWriter =  new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(productExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
