using NUnit.Framework;
using ReviewDataRetrieval;

namespace ReviewDataRetrievalTesting
{
    public class YoutubeApiResponseExplorerTest
    {
        [Test]
        public void GivenJsonFormattedReviewData_WhenGetNextPageTokenIsCalled_ThenValidNextPageTokenIsReturned()
        {
            const string expectedResult = "CDIQAA";
            var jsonExplorer = new YouTubeApiResponseExplorer(Properties.Resources.reviewTestJsonFile);
            var actualResult = jsonExplorer.GetNextPageToken();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void GivenJsonFormattedReviewData_WhenGetNumberOfResponsePageIsCalled_ThenValidNumberOfResponsePageIsReturned()
        {
            const int expectedResult = 99;
            var jsonExplorer = new YouTubeApiResponseExplorer(Properties.Resources.reviewTestJsonFile);
            var actualResult = jsonExplorer.GetNumberOfResponsePages();

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
