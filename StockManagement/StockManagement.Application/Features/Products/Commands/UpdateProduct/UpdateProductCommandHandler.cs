﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(productToUpdate);

            return Unit.Value;
        }
    }
}
