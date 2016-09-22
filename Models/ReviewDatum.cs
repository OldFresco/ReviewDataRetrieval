namespace NeedleDropReviewDataMiner.Models
{
    public class ReviewDatum
    {
        public string Title { get; set; }
        public string Rating { get; set; }

        public string ToCsv()
        {
            return Title + "," + Rating;
        }
    }
}
