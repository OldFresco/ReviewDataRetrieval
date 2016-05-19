using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public class ReviewDataConverter : IJsonConverter
    {
        private readonly string _inputData;
        private readonly ReviewRatingScanner _ratingResolver;

        public ReviewDataConverter(string inputData)
        {
            _inputData = inputData;
            _ratingResolver = new ReviewRatingScanner();
        }

        public List<ReviewDatum> ConvertJsonToReviewDataList()
        {
            var reviewDataList = new List<ReviewDatum>();
            dynamic jsonObject = JsonConvert.DeserializeObject(_inputData);
            var items = jsonObject.items;

            foreach (var item in items)
            {
                var reviewDataRecord = new ReviewDatum
                {
                    Title = item.snippet.title.ToString(),
                    Rating = _ratingResolver.FindFirstRatingOrDefault(item.snippet.description.ToString())
                };
                reviewDataList.Add(reviewDataRecord);
            }
            return reviewDataList;
        }

        public string ConvertReviewDataListToCsv(List<ReviewDatum> reviewList)
        {
            return reviewList.Aggregate("", (current, record) => current + (record.Title + "," + record.Rating)+"\n");
        }
    }
}
