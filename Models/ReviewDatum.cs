namespace NeedleDropReviewDataMiner.Models
{
    public class ReviewDatum
    {
        public string Title { get; set; }
        public string Rating { get; set; }

        public string ToCsv()
        {
            return ParseTitle(Title) + "," + Rating;
        }

        private static string ParseTitle(string rawTitle)
        {
            var preclean = rawTitle.Replace("ALBUM REVIEW", "");

            return preclean.Replace("MIXTAPE REVIEW", "");
        }
    }
}