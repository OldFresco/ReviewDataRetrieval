using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ReviewRatingResolver;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public class ReviewDataParser : IJsonParser
    {
        private readonly string _inputData;
        private readonly ReviewRatingResolver _ratingResolver;

        public ReviewDataParser(string inputData, ReviewRatingResolver ratingResolver)
        {
            _inputData = inputData;
            _ratingResolver = new ratingResolver();
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
                reviewDataList.add(reviewDataRecord)
            }           
            return reviewDataList;
        }
    }
}
