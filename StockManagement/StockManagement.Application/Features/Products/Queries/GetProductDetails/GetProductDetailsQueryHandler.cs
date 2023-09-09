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
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IMapper mapper, 
            IAsyncRepository<Product> productRepository, 
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _companyRepository = companyRepository;
        }
        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            var productDetailDto = _mapper.Map<ProductDetailsVm>(product);
            var category = new Category() { };
            var company = new Company() { };    

            if (product != null)
            {
                category = await _categoryRepository.GetByIdAsync(product.CategoryId);
                company = await _companyRepository.GetByIdAsync(product.CompanyId);
            }

            productDetailDto.Category = _mapper.Map<CategoryDto>(category);
            productDetailDto.Company = _mapper.Map<CompanyDto>(company);

            return productDetailDto;
        }
    }
}
