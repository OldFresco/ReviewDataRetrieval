namespace ReviewDataRetrieval.Models
{
    public class ReviewData
    {
        public string Title { get; set; }
        public string Rating { get; set; }

        public string ToCSV()
        {
            return Title.ToString() + "," + Rating.ToString();
        }
    }
}
