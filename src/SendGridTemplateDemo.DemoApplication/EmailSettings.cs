namespace SendGridTemplateDemo.ConsoleApplication;

public class EmailSettings
{
    public string ApiKey { get; set; }
    public string TemplateId { get; set; }
    public string SenderEmailAddress { get; set; }
    public string SenderDisplayName { get; set; }
    
    public string RecipientEmailAddress { get; set; }
    public string RecipientDisplayName { get; set; }
}