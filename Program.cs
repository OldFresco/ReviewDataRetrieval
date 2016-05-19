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
            var csvDataSet = "";
            var nextPageToken = "";

            //Get first page response to figure out whether we need to iterate over pages (as there's a 50 results per page limit)
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(playlistUrl).Result;
                if (!response.IsSuccessStatusCode) return;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                var converter = new ReviewDataConverter(responseString);
                var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();
                csvDataSet += converter.ConvertReviewDataListToCsv(listOfReviewDataRecords);

                var jsonExplorer = new YouTubeApiResponseExplorer(responseString);
                nextPageToken = jsonExplorer.GetNextPageToken();

                Console.WriteLine(csvDataSet);
            }

            //Do iteration if needed.
            while (nextPageToken != "no more tokens")
            {
                using (var client = new HttpClient())
                {
                    playlistUrl = baseUrl + "&pageToken=" + nextPageToken + "&playlistId=" + playlistId + "&key=" +
                                  apiKey;
                    var response = client.GetAsync(playlistUrl).Result;
                    if (!response.IsSuccessStatusCode) return;

                    var responseContent = response.Content;
                    var responseString = responseContent.ReadAsStringAsync().Result;
                    var converter = new ReviewDataConverter(responseString);
                    var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();
                    csvDataSet += converter.ConvertReviewDataListToCsv(listOfReviewDataRecords);

                    var jsonExplorer = new YouTubeApiResponseExplorer(responseString);
                    nextPageToken = jsonExplorer.GetNextPageToken();
                }
            }
            Console.WriteLine(csvDataSet);
            Console.ReadLine();
        }
    }
}
