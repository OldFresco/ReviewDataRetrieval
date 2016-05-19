namespace ReviewDataRetrieval.Models
{
    public class ReviewDatum
    {
        public string Title { get; set; }
        public string Rating { get; set; }

        public string ToCSV()
        {
            return Title.ToString() + "," + Rating.ToString();
        }
    }
}
