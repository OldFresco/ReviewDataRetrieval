using System;

namespace ReviewDataRetrieval
{
 public class Program
    {
        public static void Main(string[] args)
        {
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
        }
    }
}

