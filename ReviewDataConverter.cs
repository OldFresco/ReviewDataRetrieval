using System.Collections.Generic;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public class ReviewDataConverter : IJsonConverter
    {
        private readonly string _inputData;
        private readonly ReviewRatingScanner _ratingScanner;

        public ReviewDataConverter(string inputData)
        {
            _inputData = inputData;
            _ratingScanner = new ReviewRatingScanner();
        }

        public List<ReviewDatum> ConvertJsonToReviewDataList()
        {
            var reviewDataList = new List<ReviewDatum>();
            dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(_inputData);
            var items = jsonObject.items;

            foreach (var item in items)
            {
                var reviewDataRecord = new ReviewDatum
                {
                    Title = item.snippet.title.ToString(),
                    Rating = _ratingScanner.FindFirstRatingOrDefault(item.snippet.description.ToString())
                };
                reviewDataList.Add(reviewDataRecord);
            }
            return reviewDataList;
        }
    }
}
