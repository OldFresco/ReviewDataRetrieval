using System;
using System.Net.Http;

namespace ReviewDataRetrieval
{
    public class ReviewRatingDataMiner
    {
        private readonly string _outputFilePath;
        private readonly string _apiKey = Properties.Settings.Default.apiKey;
        private readonly string _playlistId;
        private readonly string _baseUrl = Properties.Settings.Default.baseUrl;
        
        public ReviewRatingDataMiner(string playlistId, string outputFilePath)
        {
            _playlistId = playlistId;
            _outputFilePath = outputFilePath;
        }              
        
        public void Execute()
        {
            var playlistUrl = _baseUrl + "&playlistId=" + _playlistId + "&key=" + _apiKey;
            var csvData = "";

            using (var client = new HttpClient())
            {
                string nextPageToken;
                do
                {
                    var response = client.GetAsync(playlistUrl).Result;
                    if (!response.IsSuccessStatusCode) return;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    var converter = new ReviewDataConverter(responseString);
                    var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();
                    csvData += converter.ConvertReviewDataListToCsv(listOfReviewDataRecords);

                    var jsonExplorer = new YouTubeApiResponseExplorer(responseString);
                    nextPageToken = jsonExplorer.GetNextPageToken();

                    if (nextPageToken != "no more tokens")
                    {
                        playlistUrl = _baseUrl + "&pageToken=" + nextPageToken + "&playlistId=" + _playlistId + "&key=" + _apiKey;
                    }
                } while (nextPageToken != "no more tokens");
            }

            Console.WriteLine(csvData);
            Console.ReadLine();
        }
    }
}