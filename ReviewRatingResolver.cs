using System.Collections.Generic;

namespace ReviewDataRetrieval
{
    public class ReviewRatingResolver
    {
        private readonly List<string> ratingList = new List<string>();
        
        public ReviewRatingResolver()
        {
            ratingList.Add("0/10");
            ratingList.Add("1/10");
            ratingList.Add("2/10");
            ratingList.Add("3/10");
            ratingList.Add("4/10");
            ratingList.Add("5/10");
            ratingList.Add("6/10");
            ratingList.Add("7/10");
            ratingList.Add("8/10");
            ratingList.Add("9/10");
            ratingList.Add("10/10");
        }
                
        public string RetrieveRatingFromDescription(string reviewDescription)
        {
            var descriptionContentArray = reviewDescription.Split(null);
            var rating = "rating not found";
            
            foreach(var word in descriptionContentArray)
            {
                if (StringIsRating(word))
                {
                    rating = word;
                }
            }
            return rating;        
        }
        
        public bool StringIsRating(string word)
        {
            return ratingList.Contains(word);
        }
     }
}