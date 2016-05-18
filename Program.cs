namespace ReviewDataRetrieval
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var apiKey = "AIzaSyC198AyRLiVMrcVZV-Wfs8A3SimJNh8VLQ";
            var playlistId = "PLP4CSgl7K7orSnEBkcBRqI5fDgKSs5c8o";
            var baseUrl = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50";
            var needleDropPlaylistUrl = baseUrl+"&playlistId="+playlistId+"&key="+apiKey;
        }
    }
}
