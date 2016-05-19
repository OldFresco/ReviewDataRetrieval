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
            return _deserializedJsonResponse.nextPageToken == null ? "no more tokens" : _deserializedJsonResponse.nextPageToken.ToString();
        }

        public int GetNumberOfUploads()
        {
            var numberOfUploads = 0;
            int.TryParse(_deserializedJsonResponse.pageInfo.totalResults.ToString(), out numberOfUploads); ;

            return numberOfUploads;
        }
    }
}
