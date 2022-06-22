using SendGrid;
using SendGrid.Helpers.Mail;

var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
var client = new SendGridClient(apiKey);
var from = new EmailAddress("{ Your verified email address }", "{ Sender display name }");
var to = new EmailAddress("{ Recipient email address }", "{ Recipient display name }");

var subject = "Testing the API key";
var plainTextContent = "Testing a simple email";
var htmlContent = "<strong>Testing simple email in HTML</strong>";
var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
var response = await client.SendEmailAsync(msg);
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Email has been sent successfully");
}

// var templateId = "{ Your template id }";
// var dynamicTemplateData = new
// {
//     subject = $"To-Do List for {DateTime.UtcNow:MMMM}",
//     recipientName = "Demo User", 
//     todoItemList = new[]
//     {
//         new { title = "Organize invoices", dueDate = "11 June 2022", status = "Completed" },
//         new { title = "Prepare taxes", dueDate = "12 June 2022", status = "In progress" },
//         new { title = "Submit taxes", dueDate = "25 June 2022", status = "Pending" },
//     }
// };
//
// var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
// var response = await client.SendEmailAsync(msg);
// if (response.IsSuccessStatusCode)
// {
//     Console.WriteLine("Email has been sent successfully");
// }