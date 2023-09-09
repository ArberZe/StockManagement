
using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Suppliers.Queries.GetSupplierList
{
    public class GetSupplierListQueryHandler : IRequestHandler<GetSupplierListQuery, List<SupplierListVm>>
    {
        private readonly IAsyncRepository<Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierListQueryHandler(IAsyncRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<List<SupplierListVm>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            var allSuppliers = (await _supplierRepository.ListAllAsync()).OrderByDescending(e => e.CreatedDate);
            
            return _mapper.Map<List<SupplierListVm>>(allSuppliers);
        }
    }
}
