using StockManagement.Application.Models.Mail;

namespace StockManagement.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}