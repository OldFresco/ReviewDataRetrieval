using System.Linq;

namespace NeedleDropReviewDataMiner
{
    public class ReviewType
    {
        public bool Validate(string reviewTitle)
        {
            var words = reviewTitle.Split(' ');

            return words.Any(word => word == "ALBUM" || word == "REVIEW" || word == "MIXTAPE");
        }
    }
}
