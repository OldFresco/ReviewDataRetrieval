using System;
using Newtonsoft.Json;

namespace ReviewDataRetrieval
{
    public class YouTubeApiResponseExplorer
    {
        private readonly dynamic _deserializedJsonResponse;

        public YouTubeApiResponseExplorer(string rawJson)
        {
            _deserializedJsonResponse = JsonConvert.DeserializeObject(rawJson);
        }

        public string GetNextPageToken()
        {
            var token = _deserializedJsonResponse.nextPageToken.ToString();

            return token;
        }

        public int GetNumberOfResponsePages()
        {
            var numberOfPages = 0;
            int.TryParse(_deserializedJsonResponse.pageInfo.totalResults.ToString(), out numberOfPages); ;

            return numberOfPages;
        }
    }
}
