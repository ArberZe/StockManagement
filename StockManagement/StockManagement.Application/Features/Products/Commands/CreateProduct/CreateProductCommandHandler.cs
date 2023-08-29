using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StockManagement.Application.Contracts.Infrastructure;
using StockManagement.Application.Contracts.Persistence;
using StockManagement.Application.Models.Mail;
using StockManagement.Domain.Entities;

namespace StockManagement.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IMapper mapper, 
        IProductRepository productRepository, 
        IEmailService emailService, 
        ILogger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }
    
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createProductCommandResponse = new CreateProductCommandResponse();

        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createProductCommandResponse.Success = false;
            createProductCommandResponse.ValidationErrors = new List<string>();
            foreach(var error in validationResult.Errors)
            {
                createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }

            return createProductCommandResponse;
        }

        var product = _mapper.Map<Product>(request);

        product = await _productRepository.AddAsync(product);
        createProductCommandResponse.Product = _mapper.Map<CreateProductDto>(product);

        //Sending email notification to admin address
        var email = new Email() { To = "arberzeka01@gmail.com", Body = $"A new product was created: {request}", Subject = "A new product was created" };

        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Mailing about event {product.ProductId} failed due to an error with the mail service: {ex.Message}");

        }

        return createProductCommandResponse;
    }
}