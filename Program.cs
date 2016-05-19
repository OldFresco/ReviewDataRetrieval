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
            var needleDropPlaylistUrl = baseUrl + "&playlistId=" + playlistId + "&key=" + apiKey;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(needleDropPlaylistUrl).Result;

                if (!response.IsSuccessStatusCode) return;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                var converter = new ReviewDataConverter(responseString);
                var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();

                var csvDataSet = listOfReviewDataRecords.Aggregate("", (current, record) => current + (record.ToCSV() + "\n"));
                Console.WriteLine(@"Number of Records Found: {0}", listOfReviewDataRecords.Count.ToString());
            }           
            Console.ReadLine();
        }
    }
}
