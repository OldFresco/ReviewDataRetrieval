using System;
using System.Linq;
using System.Net.Http;

namespace ReviewDataRetrieval
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var apiKey = Properties.Settings.Default.apiKey;
            var playlistId = Properties.Settings.Default.playlistId;
            var baseUrl = Properties.Settings.Default.baseUrl;
            var playlistUrl = baseUrl + "&playlistId=" + playlistId + "&key=" + apiKey;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(playlistUrl).Result;
                if (!response.IsSuccessStatusCode) return;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                var jsonExplorer = new YouTubeApiResponseExplorer(responseString);

                var numberOfPages = jsonExplorer.GetNumberOfResponsePages();
                var nextPageToken = (numberOfPages > 1) ? jsonExplorer.GetNextPageToken() : "";
                var csvDataSet = "";

                for (var pageNumber = 1; pageNumber < numberOfPages + 1; pageNumber++)
                {
                    var converter = new ReviewDataConverter(responseString);
                    var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();
                }
            }           
            Console.ReadLine();
        }
    }
}
