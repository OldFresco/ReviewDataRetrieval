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
            var reviewParser = new ReviewDataConverter(Properties.Resources.reviewTestJsonFile);
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
