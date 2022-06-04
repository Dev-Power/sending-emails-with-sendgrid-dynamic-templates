using Microsoft.Extensions.Configuration;
using SendGridTemplateDemo.ConsoleApplication;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var rssSettings = config.GetRequiredSection("RssSettings").Get<RssSettings>();
var emailSettings = config.GetRequiredSection("EmailSettings").Get<EmailSettings>();

var rssManager = new RssManager(rssSettings);
var latestBlogPosts = await rssManager.GetLatestBlogPosts(5);
var emailManager = new EmailManager(emailSettings);
var dynamicEmailData = new
{
    recipientName = emailSettings.RecipientDisplayName,
    blogPostList = latestBlogPosts.Select(b => new { b.Title, b.Link })
};
await emailManager.SendTemplatedEmail(emailSettings.RecipientEmailAddress, emailSettings.RecipientDisplayName, dynamicEmailData);