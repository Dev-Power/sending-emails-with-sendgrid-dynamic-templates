using SendGrid;
using SendGrid.Helpers.Mail;

var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
var client = new SendGridClient(apiKey);
var from = new EmailAddress("{verified email address}", "Blog Post Digest");
var to = new EmailAddress("{recipient email address}", "{recipient display name}");
var templateId = "{dynamic template id}";
var dynamicTemplateData = new
{
    recipientName = "Demo User", 
    blogPostList = new[]
    {
        new { title = "title 1", url = "https://twilio.com/blog/post1" },
        new { title = "title 2", url = "https://twilio.com/blog/post2" }
    }
};

var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
var response = await client.SendEmailAsync(msg);
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Email has been sent successfully");
}
