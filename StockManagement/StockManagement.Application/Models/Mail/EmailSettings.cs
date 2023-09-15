namespace StockManagement.Application.Models.Mail;

public class EmailSettings
{
    #pragma warning disable IDE1006 // Naming Styles
        public string arber01GmailKey { get; set; } = String.Empty;
    #pragma warning restore IDE1006 // Naming Styles
    public string ApiKey { get; set; } = String.Empty;
    public string FromAddress { get; set; } = String.Empty;
    public string FromName { get; set; } = String.Empty;
}