using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Categories.Queries.GetCategoriesByCreatedDateDescending
{
    public class GetCategoriesByCreatedDateDescendingQueryHandler : IRequestHandler<GetCategoriesByCreatedDateDescendingQuery, List<CategoryListDescendingOrderedVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesByCreatedDateDescendingQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryListDescendingOrderedVm>> Handle(GetCategoriesByCreatedDateDescendingQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.ListCategoriesByCreatedDateDescending();
            return _mapper.Map<List<CategoryListDescendingOrderedVm>>(list);
        }
    }
}
