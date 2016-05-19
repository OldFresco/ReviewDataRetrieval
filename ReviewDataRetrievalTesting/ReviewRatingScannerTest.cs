using NUnit.Framework;
using ReviewDataRetrieval;

namespace ReviewDataRetrievalTesting
{
    public class ReviewRatingScannerTest
    {
        [Test]
        public void GivenReviewDescriptionContainingRating_WhenFindFirstRatingOrDefaultIsCalled_ThenValidRatingIsReturned()
        {
            const string descriptionString = @"who random0934j/49f test 305/1034 asg4b 1/10. sdf3/10 5/10";
            const string expectedRating = "5/10";
            var ratingScanner = new ReviewRatingScanner();
            var actualRating = ratingScanner.FindFirstRatingOrDefault(descriptionString);
            
            Assert.AreEqual(expectedRating, actualRating);
        }

        [Test]
        public void GivenReviewDescriptionWithoutRating_WhenFindFirstRatingOrDefaultIsCalled_ThenDefaultMessageIsReturned()
        {
            const string descriptionString = @"who random0934j/49f test 305/1034 asg4b 1/10. sdf3/10 5//10";
            const string expectedRating = "rating not found";
            var ratingScanner = new ReviewRatingScanner();
            var actualRating = ratingScanner.FindFirstRatingOrDefault(descriptionString);

            Assert.AreEqual(expectedRating, actualRating);
        }
    }
}
