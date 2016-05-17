using System.Collections.Generic;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public class ReviewDataParser : IJsonParser
    {
        private readonly string _inputData;
        private readonly ReviewRatingResolver _ratingResolver;

        public ReviewDataParser(string inputData)
        {
            _inputData = inputData;
            _ratingResolver = new ReviewRatingResolver();
        }

        public List<ReviewData> ParseJsonData()
        {
            var reviewDataList = new List<ReviewData>();
            dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(_inputData);
            var items = jsonObject.items;

            foreach (var item in items)
            {
                var reviewDataRecord = new ReviewData
                {
                    Title = item.snippet.title,
                    Rating = _ratingResolver.RetrieveRatingFromDescription(item.snippet.description)
                };
                reviewDataList.Add(reviewDataRecord);
            }
            return reviewDataList;
        }
    }
}
