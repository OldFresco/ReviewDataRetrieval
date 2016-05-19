using System.Net.Http;

namespace ReviewDataRetrieval
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var apiKey = "AIzaSyC198AyRLiVMrcVZV-Wfs8A3SimJNh8VLQ";
            var playlistId = "PLP4CSgl7K7orSnEBkcBRqI5fDgKSs5c8o";
            var baseUrl = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50";
            var needleDropPlaylistUrl = baseUrl + "&playlistId=" + playlistId + "&key=" + apiKey;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(needleDropPlaylistUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    
                    var parser = new ReviewDataParser(responseString);
                    
                    var listOfReviewDataRecords = parser.ParseJsonData();
                    
                    var csvDataSet = "";
                    
                    foreach (var record in listOfReviewDataRecords)
                    {
                        csvDataSet += record.ToCSV();
                    }
                }
            }
        }
    }
}
