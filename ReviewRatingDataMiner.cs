using System;
using System.Net.Http;

namespace ReviewDataRetrieval
{
    public class ReviewRatingDataMiner
    {
        private readonly string _outputFilePath;
        private readonly string _ApiKey = Properties.Settings.Default.apiKey;
        private readonly string _playlistId;
        private readonly string _baseUrl = Properties.Settings.Default.baseUrl;
        
        public ReviewRatingDataMiner(string playlistId, string outputFilePath)
        {
            _playlistId = playlistId;
            _outputFilePath = outputFilePath;
        }              
        
        public void Execute()
        {
            var playlistUrl = baseUrl + "&playlistId=" + playlistId + "&key=" + apiKey;
            var csvDataSet = "";
            string nextPageToken;
            
            using (var client = new HttpClient())
            {
                do
                { 
                    var response = client.GetAsync(playlistUrl).Result;
                    if (!response.IsSuccessStatusCode) return;
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    var converter = new ReviewDataConverter(responseString);
                    var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();
                    csvDataSet += converter.ConvertReviewDataListToCsv(listOfReviewDataRecords);

                    var jsonExplorer = new YouTubeApiResponseExplorer(responseString);
                    nextPageToken = jsonExplorer.GetNextPageToken();
                    playlistUrl  = (nextPageToken != null) ? = baseUrl + "&pageToken=" + nextPageToken + "&playlistId=" + playlistId + "&key=" +
                                    apiKey : "";
                } while (nextPageToken != null);
            }
            
            Console.WriteLine(csvDataSet);
            Console.ReadLine();
        }
    }
}