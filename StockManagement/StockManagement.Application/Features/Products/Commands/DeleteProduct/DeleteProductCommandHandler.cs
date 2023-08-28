using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.ProductId);

            if (productToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            await _productRepository.DeleteAsync(productToDelete);

            return Unit.Value;
        }
    }
}
