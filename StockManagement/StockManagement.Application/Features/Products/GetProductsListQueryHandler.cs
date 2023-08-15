using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery
        , List<ProductListVm>>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _productRepository.GetAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<ProductListVm>>(allProducts);
        }
    }
}
