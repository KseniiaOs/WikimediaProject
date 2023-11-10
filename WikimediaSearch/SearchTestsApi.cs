using System.Net;
using Newtonsoft.Json;
using PagesModel;
using WikiPageModel;

namespace WikiApi;

public class SearchApiTests 
{
    private ApiConfig _apiConfig;
    private WikimediaApi _wikimediaApi;

    [SetUp]
    public void Setup()
    {
        _apiConfig = new ApiConfig("https://api.wikimedia.org/", "wikipedia", "en");
        _wikimediaApi = new WikimediaApi(_apiConfig);
    }

    private Pages? GetPagesByContent(string query)
    {
        var response = _wikimediaApi.GetPagesByContent(query);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Request wasn't successful, status code was  {response.StatusCode}");
        });

        return JsonConvert.DeserializeObject<Pages?>(response.Content);
    }

    private bool IsPageWithTitleFound(List<Page> pages, string title)
    {
        foreach (var page in pages)
        {
            if (page.title == title)
            {
                return true;
            }
        }
        return false;
    }

    [Test]
    public void SearchPageByContentTest()
    {
        string searchQuery = "furry rabbits";
        string expectedTitle = "Sesame Street";

        var response = GetPagesByContent(searchQuery);
     
        Assert.That(response.pages, Is.Not.Empty, $"Request didn't return results");

        bool isExpectedTitleFound = IsPageWithTitleFound(response.pages, expectedTitle);

        Assert.That(isExpectedTitleFound, Is.True, "No page with the expected title was found in the response.");
    }

    [Test]
    public void CheckLatestTimestampTest()
    {
        string searchQuery = "furry rabbits";
        string expectedTitle = "Sesame Street";
        string urlTitle = "Sesame_Street";

        var response = GetPagesByContent(searchQuery);

        bool isExpectedTitleFound = IsPageWithTitleFound(response.pages, expectedTitle);

        Assert.That(isExpectedTitleFound, Is.True, "No page with the expected title was found in the response.");

        var responseWiki = _wikimediaApi.GetWikiPageByTitle(urlTitle);
        Assert.That(responseWiki.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            $"Request wasn't successful {responseWiki.StatusCode}");

        WikiPage? wikiPage = JsonConvert.DeserializeObject<WikiPage?>(responseWiki.Content);

        Assert.That(wikiPage?.latest.timestamp, Is.GreaterThan(DateTime.Parse("2023-08-17")),
            "The latest timestamp is not greater than '2023-08-17'.");
    }
}
