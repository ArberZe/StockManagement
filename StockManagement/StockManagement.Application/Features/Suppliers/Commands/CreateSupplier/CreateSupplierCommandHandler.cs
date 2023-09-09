
using AutoMapper;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierCommandResponse>
    {
        private readonly IAsyncRepository<Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IAsyncRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task<CreateSupplierCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var createSupplierCommandResponse = new CreateSupplierCommandResponse();

            var validator = new CreateSupplierCommandValidator();
            var validationResponse = await validator.ValidateAsync(request);

            if(validationResponse.Errors.Count > 0)
            {
                createSupplierCommandResponse.Success = false;
                createSupplierCommandResponse.ValidationErrors = new List<string>();
                foreach(var error in validationResponse.Errors)
                {
                    createSupplierCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                return createSupplierCommandResponse;
            }

            var supplier = _mapper.Map<Supplier>(request);

            supplier = await _supplierRepository.AddAsync(supplier);

            createSupplierCommandResponse.Supplier = _mapper.Map<CreateSupplierDto>(supplier);

            return createSupplierCommandResponse;
        }
    }
}
