using System.Collections.Generic;
using System.Linq;

namespace ReviewDataRetrieval
{
    public class ReviewRatingScanner
    {
        private readonly List<string> ratingList = new List<string>();

        public ReviewRatingScanner()
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

        public string FindFirstRatingOrDefault(string reviewDescription)
        {
            var descriptionContentArray = reviewDescription.Split(null);
            var rating = "rating not found";

            foreach (var word in descriptionContentArray.Where(StringIsRating))
            {
                rating = word;
            }
            return rating;
        }

        public bool StringIsRating(string word)
        {
            return ratingList.Contains(word);
        }
    }
}