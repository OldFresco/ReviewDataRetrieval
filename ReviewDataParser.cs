using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public class ReviewDataParser : IJsonParser
    {
        private readonly string _inputData;

        public ReviewDataParser(string inputData)
        {
            _inputData = inputData;
        }

        public List<ReviewData> ParseJsonData()
        {
            var reviewDataList = new List<ReviewData>();
            dynamic jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(_inputData);
            var items = jsonObject.items;

            foreach (var item in items)
            {
                var reviewDataElement = new ReviewData
                {
                    Title = item.snippet.title,
                    Score = RetrieveDescriptionScore(item.snippet.description)
                };
            }
        }

        public string RetrieveDescriptionScore(string description)
        {
            var descriptionContentArray = description.Split(null);

            foreach (var word in descriptionContentArray.Where(word => isThisWordAScore))
            {
                return word;
            }

            return "Couldn't resolve a score";
        }
    }
}
