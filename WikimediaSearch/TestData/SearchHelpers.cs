using Newtonsoft.Json;
using System.Net;
using PagesModel;
using WikiPageModel;

namespace WikiApi
{
    public class WikimediaApi
	{
        private readonly ApiConfig _apiConfig;
        private readonly RestClient _client;

        public WikimediaApi(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
            _client = new RestClient(_apiConfig.HostName);
        }

        public RestResponse<Pages> GetPagesByContent(string query, int limit = 50)
        {
            var request = new RestRequest($"/core/v1/{_apiConfig.Project}/{_apiConfig.Language}/search/page", Method.Get);
            request.AddParameter("q", query);
            request.AddParameter("limit", limit);

            var response = _client.Execute<Pages>(request);

            return response;
        }

        public RestResponse<WikiPage> GetWikiPageByTitle(string title)
        {
            var encodedTitle = Uri.EscapeDataString(title);
            var request = new RestRequest($"core/v1/{_apiConfig.Project}/{_apiConfig.Language}/page/{encodedTitle}/bare", Method.Get);
            var response = _client.Execute<WikiPage>(request);

            return response;
        }
    }
}

