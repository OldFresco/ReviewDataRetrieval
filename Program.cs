using System;
<<<<<<< HEAD
=======
using System.Linq;
using System.Net.Http;
>>>>>>> 23fd8220c91a050b96bbd83f972db5d4ecd3ff55

namespace ReviewDataRetrieval
{
 public class Program
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            Console.WriteLine(@"
 ========================================================  
  _   _               _ _      ____                  
 | \ | | ___  ___  __| | | ___|  _ \ _ __ ___  _ __  
 |  \| |/ _ \/ _ \/ _` | |/ _ \ | | | '__/ _ \| '_ \ 
 | |\  |  __/  __/ (_| | |  __/ |_| | | | (_) | |_) |
 |_|_\_|\___|\___|\__,_|_|\___|____/|_|  \___/| .__/ 
 |  _ \  __ _| |_ __ _  |  \/  (_)_ __   ___ _|_|    
 | | | |/ _` | __/ _` | | |\/| | | '_ \ / _ \ '__|   
 | |_| | (_| | || (_| | | |  | | | | | |  __/ |      
 |____/ \__,_|\__\__,_| |_|  |_|_|_| |_|\___|_|      
 
 =========================================================
                                                     ");
            Console.WriteLine("  Ay! Welcome to the NeedleDrop Data Mining Console App");
            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------------------------");
            Console.WriteLine(@"
            
Select one of the following options to start:");
            Console.WriteLine(@"
            
1. Do this
2. Do that
3. Do this
4. Do that
5. Exit
");
            Console.WriteLine("\n");
            bool exit = false;
            do
            {
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
		                Console.WriteLine();
                        break;
                    case "2":
		                Console.WriteLine();
                        break;
                    case "3":
		                Console.WriteLine();
                        break;
                    case "4":
		                Console.WriteLine();
                        break;
                    case "5":
                        exit = true;
		                Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Sorry, not happening! Try again.");
                        break;
                }
                Console.WriteLine();    
            } while (exit == false);                                                                
=======
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
>>>>>>> 23fd8220c91a050b96bbd83f972db5d4ecd3ff55
        }
    }
}

