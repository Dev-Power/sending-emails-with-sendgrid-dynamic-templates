using System.Xml;
using SendGridTemplateDemo.ConsoleApplication;

public class RssManager
{
    private readonly RssSettings _rssSettings;

    public RssManager(RssSettings rssSettings)
    {
        _rssSettings = rssSettings;
    }
    
    public async Task<List<BlogPost>> GetLatestBlogPosts(int numberOfPostsToReturn)
    {
        string rawRssFeed = await DownloadRssFeed();
        
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(rawRssFeed);
        XmlNodeList itemNodeList = xmlDocument.SelectNodes("/rss/channel/item");

        var results = new List<BlogPost>();
        
        for (int i = 0; i < numberOfPostsToReturn; i++)
        {
            XmlNode titleNode = itemNodeList[i].SelectSingleNode("title");
            XmlNode linkNode = itemNodeList[i].SelectSingleNode("link");
            XmlNode descriptionNode = itemNodeList[i].SelectSingleNode("description");
            
            var blogPost = new BlogPost
            {
                Title = titleNode.InnerText,
                Link = linkNode.InnerText,
                // Description = descriptionNode.InnerText
            };
            
            results.Add(blogPost);
        }

        return results;
    }
    
    private async Task<string> DownloadRssFeed()
    {
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(_rssSettings.FeedUrl))
            {
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    using (StreamReader reader = new StreamReader(streamToReadFrom))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }
    }
}