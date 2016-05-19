using System.Collections.Generic;
using NUnit.Framework;
using ReviewDataRetrieval.Models;
using ReviewDataRetrieval;

namespace ReviewDataRetrievalTesting
{
    public class ReviewDataConverterTest
    {
        [Test]
        public void GivenJsonFormattedReviewData_WhenConvertJsonToReviewDataListIsCalled_ThenValidReviewListObjectIsReturned()
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

        [Test]
        public void GivenJsonFormattedReviewData_WhenConvertReviewDataListToCsvIsCalled_ThenCSVDataIsReturned()
        {
            const string expectedResult = "TestA,5/10\nTestB,8/10\n";
            var reviewParser = new ReviewDataConverter(Properties.Resources.reviewTestJsonFile);
            var reviewDataList = new List<ReviewDatum>();        
            var reviewRecordA = new ReviewDatum
            {
                Title = "TestA",
                Rating = "5/10"
            };
            var reviewRecordB = new ReviewDatum
            {
                Title = "TestB",
                Rating = "8/10"
            };

            reviewDataList.Add(reviewRecordA);
            reviewDataList.Add(reviewRecordB);

            var actualResult = reviewParser.ConvertReviewDataListToCsv(reviewDataList);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
