using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Infrastructure;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Queries.GetProductsExport
{
    public class GetProductsExportQueryHandler : IRequestHandler<GetProductsExportQuery, ProductExportFileVm>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetProductsExportQueryHandler(IAsyncRepository<Product> productRepository, IMapper mapper, ICsvExporter csvExporter)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _csvExporter = csvExporter;
        }

        public async Task<ProductExportFileVm> Handle(GetProductsExportQuery request, CancellationToken cancellationToken)
        {
            var allProducts = _mapper.Map<List<ProductExportDto>>((await _productRepository.ListAllAsync()).OrderByDescending(x => x.CreatedDate));

            var fileData = _csvExporter.ExportProductsToCsv(allProducts);

            var productFileExportDto = new ProductExportFileVm() { ContentType = "text/csv", Data = fileData, ProductExportFilename = $"{Guid.NewGuid()}.csv" };

            return productFileExportDto;
        }
    }
}
