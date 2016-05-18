using NUnit.Framework;
using ReviewDataRetrieval;

namespace ReviewDataRetrievalTesting
{
    public class ReviewRatingResolverTest
    {
        [Test]
        public void GivenReviewDescriptionContainingRating_WhenRetrieveRatingFromDescriptionIsCalled_ThenValidRatingIsReturned()
        {
            const string descriptionString = @"who random0934j/49f test 305/1034 asg4b 1/10. sdf3/10 5/10";
            const string expectedRating = "5/10";
            var ratingResolver = new ReviewRatingResolver();
            var actualRating = ratingResolver.RetrieveRatingFromDescription(descriptionString);
            
            Assert.AreEqual(expectedRating, actualRating);
        }
    }
}
