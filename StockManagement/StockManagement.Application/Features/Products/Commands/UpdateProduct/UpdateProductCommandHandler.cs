using AutoMapper;
using StockManagement.Application.Exceptions;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using StockManagement.Application.Features.Products.Commands.CreateProduct;

namespace StockManagement.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProductCommandResponse = new UpdateProductCommandResponse();

            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateProductCommandResponse.Success = false;
                updateProductCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                return updateProductCommandResponse;
            }

            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(productToUpdate);
            updateProductCommandResponse.Message = "Produkti u editua me sukses";

            return updateProductCommandResponse;
        }
    }
}

