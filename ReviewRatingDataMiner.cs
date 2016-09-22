using System;
using System.Net.Http;
using NeedleDropReviewDataMiner;

namespace NeedleDropReviewDataMiner
{
    public class ReviewRatingDataMiner
    {
        private readonly string _apiKey;
        private readonly string _playlistId;
        private readonly string _baseUrl;
        private string _reviewDataCsv;
        
        public ReviewRatingDataMiner(string playlistId)
        {
            _playlistId = playlistId;
            _apiKey = Properties.Settings.Default.apiKey;
            _baseUrl = Properties.Settings.Default.baseUrl;
            _reviewDataCsv = "";
        }              
        
        public void Execute()
        {
            var playlistUrl = _baseUrl + "&playlistId=" + _playlistId + "&key=" + _apiKey;

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
                    _reviewDataCsv += converter.ConvertReviewDataListToCsv(listOfReviewDataRecords);

                    var jsonExplorer = new YouTubeApiResponseExplorer(responseString);
                    nextPageToken = jsonExplorer.GetNextPageToken();

                    if (nextPageToken != "no more tokens")
                    {
                        playlistUrl = _baseUrl + "&pageToken=" + nextPageToken + "&playlistId=" + _playlistId + "&key=" + _apiKey;
                    }
                } while (nextPageToken != "no more tokens");
            }

            Console.WriteLine(_reviewDataCsv);
            Console.ReadLine();
        }

        public void GetReviewDataString()
        { }

        public void SaveAsCsv()
        { }
    }
}