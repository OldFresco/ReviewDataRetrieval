using NUnit.Framework;
using System.IO;
using ReviewDataRetrieval.Models;
using ReviewDataRetrieval;

namespace ReviewDataRetrievalTesting
{
    public class ReviewDataConverterTest
    {
        [Test]
        public void GivenJsonFormattedReviewData_WhenParseJsonDataIsCalled_ThenValidReviewListObjectIsReturned()
        {
            var jsonReviewData = File.ReadAllText(@"C:\Users\kojo.hinson\Documents\Dev\Sandpit\needledrop-review-data-mining-vs\needledrop-review-data-mining\ReviewDataRetrievalTesting\review_test_data.json");
            var reviewParser = new ReviewDataConverter(jsonReviewData);
            var expectedResult = new ReviewDatum
            {
                Title = "James Blake - The Colour In Anything ALBUM REVIEW",
                Rating = "5/10"
            };

            var actualResult = reviewParser.ConvertJsonToReviewDataList()[0];

            Assert.AreEqual(actualResult.Title, expectedResult.Title);
            Assert.AreEqual(actualResult.Rating, expectedResult.Rating);
        }
    }
}
