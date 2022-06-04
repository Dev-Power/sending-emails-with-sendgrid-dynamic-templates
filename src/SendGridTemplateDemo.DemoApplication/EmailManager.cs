using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridTemplateDemo.ConsoleApplication;

public class EmailManager
{
    private readonly EmailSettings _emailSettings;
    
    public EmailManager(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }
    
    public async Task SendTemplatedEmail(string recipientEmail, string recipientDisplayName, object dynamicTemplateData)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var from = new EmailAddress(_emailSettings.SenderEmailAddress, _emailSettings.SenderDisplayName);
        var to = new EmailAddress(recipientEmail, recipientDisplayName);
        var templateId = _emailSettings.TemplateId;
        
        var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
        var response = await client.SendEmailAsync(msg);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Email has been sent successfully");
        }
    }
}