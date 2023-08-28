using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository, IAsyncRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            var productDetailDto = _mapper.Map<ProductDetailsVm>(product);
            var category = new Category() { };

            if (product != null)
            {
                category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            }

            productDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return productDetailDto;
        }
    }
}
