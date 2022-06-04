
using SendGrid;
using SendGrid.Helpers.Mail;

var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
var client = new SendGridClient(apiKey);
var from = new EmailAddress("{verified email address}", "Blog Post Digest");
var subject = "Testing the API key";
var to = new EmailAddress("{recipient email address}", "{recipient display name}");
var plainTextContent = "Testing a simple email";
var htmlContent = "<strong>Testing simple email in HTML</strong>";
var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
var response = await client.SendEmailAsync(msg);
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Email has been sent successfully");
}