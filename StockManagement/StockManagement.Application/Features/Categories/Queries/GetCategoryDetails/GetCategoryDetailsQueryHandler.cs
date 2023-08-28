using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsVm>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailsQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDetailsVm> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            return _mapper.Map<CategoryDetailsVm>(category);
        }
    }
}
