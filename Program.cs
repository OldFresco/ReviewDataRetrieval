using System;
using System.Linq;
using System.Net.Http;

namespace ReviewDataRetrieval
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const string apiKey = "AIzaSyC198AyRLiVMrcVZV-Wfs8A3SimJNh8VLQ";
            const string playlistId = "PLP4CSgl7K7orSnEBkcBRqI5fDgKSs5c8o";
            const string baseUrl = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50";
            const string needleDropPlaylistUrl = baseUrl + "&playlistId=" + playlistId + "&key=" + apiKey;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(needleDropPlaylistUrl).Result;

                if (!response.IsSuccessStatusCode) return;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;
                var converter = new ReviewDataConverter(responseString);
                var listOfReviewDataRecords = converter.ConvertJsonToReviewDataList();

                var csvDataSet = listOfReviewDataRecords.Aggregate("", (current, record) => current + (record.ToCSV() + "\n"));
                Console.WriteLine("Number of Records Found: " + listOfReviewDataRecords.Count.ToString());
            }
            Console.ReadLine();
        }
    }
}

