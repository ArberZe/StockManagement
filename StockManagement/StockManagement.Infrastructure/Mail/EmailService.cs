using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using StockManagement.Application.Contracts.Infrastructure;
using StockManagement.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using Mailjet.Client;
using Newtonsoft.Json.Linq;
using Mailjet.Client.Resources;
using System.Net.Mail;
using System.Net;
using System.Reflection;

namespace StockManagement.Infrastructure.Mail;

public class EmailService: IEmailService
{
    public EmailSettings _emailSettings { get; }
    public ILogger<EmailService> _logger { get; }

    public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
    {
        _emailSettings = mailSettings.Value;
    }

    public async Task<bool> SendEmail(Email email)
    {
        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        /*********************************/
/*        MailjetClient client = new MailjetClient(_emailSettings.ApiKey, "bd218453fd968a84458b6bae8f54e3d0");
        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
           .Property(Send.FromEmail, from.Email)
           .Property(Send.FromName, from.Name)
           .Property(Send.Subject, email.Subject)
           .Property(Send.TextPart, email.Body)
           .Property(Send.HtmlPart, "<h3>Vizito listën e produkteve <a href=\"https://localhost:7161/productoverview\">StockManagement App</a>!<br />")
           .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", $"{new EmailAddress(email.To)}"}
                 }
               });
        MailjetResponse response = await client.PostAsync(request);*/
        /***********************************/
        /*******************************************/

        var body = email.Body;
        var message = new MailMessage();
        message.To.Add(email.To); 
        message.From = new MailAddress(from.Email); 
        message.Subject = email.Subject;
        message.Body = string.Format(body, from.Name, from.Email, email.Body);
        message.IsBodyHtml = true;
        //message.Attachments.Add(attachment);

        using (var smtp = new SmtpClient())
        {
            var credential = new NetworkCredential
            {
                UserName = "arberzeka01@gmail.com",  // replace with valid value
                Password = _emailSettings.ApiKey  // replace with valid value
            };
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(message);
        }

        /**********************************************/
        _logger.LogInformation("Email sent");

       /* if (response.StatusCode == (int)System.Net.HttpStatusCode.Accepted || response.StatusCode == (int)System.Net.HttpStatusCode.OK)
            return true;*/

        _logger.LogError($"Email sending failed!");

        return false;
    }
}