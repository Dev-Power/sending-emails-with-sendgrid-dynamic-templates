﻿using SendGrid;
using SendGrid.Helpers.Mail;

#region Set up Client
var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
var client = new SendGridClient(apiKey);
var from = new EmailAddress("{verified email address}", "Blog Post Digest");
var to = new EmailAddress("{recipient email address}", "{recipient display name}");
#endregion

#region Simple Email Example
var subject = "Testing the API key";
var plainTextContent = "Testing a simple email";
var htmlContent = "<strong>Testing simple email in HTML</strong>";
var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
var response = await client.SendEmailAsync(msg);
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Email has been sent successfully");
}
#endregion

// #region Dynamic Email Example
// var templateId = "{dynamic template id}";
// var dynamicTemplateData = new
// {
//     recipientName = "Demo User", 
//     todoItemList = new[]
//     {
//         new { Title = "Organize invoices", DueDate = "11 June 2022", Status = "Completed" },
//         new { Title = "Prepare taxes", DueDate = "12 June 2022", Status = "In progress" },
//         new { Title = "Submit taxes", DueDate = "25 June 2022", Status = "Pending" },
//     }
// };
//
// var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
// var response = await client.SendEmailAsync(msg);
// if (response.IsSuccessStatusCode)
// {
//     Console.WriteLine("Email has been sent successfully");
// }
// #endregion