using NUnit.Framework;

namespace NeedleDropReviewDataMiner
{
    [TestFixture]
    public class ReviewDescriptionScannerTest
    {
        [Test]
        public void GivenReviewDescriptionContainingRating_WhenFindFirstRatingOrDefaultIsCalled_ThenValidRatingIsReturned()
        {
            const string descriptionString = @"who random0934j/49f test 305/1034 asg4b 1/10. sdf3/10 5/10";
            const string expectedRating = "5/10";
            var descriptionScanner = new ReviewDescriptionScanner();
            var actualRating = descriptionScanner.FindFirstRatingOrDefault(descriptionString);
            
            Assert.AreEqual(expectedRating, actualRating);
        }

        [Test]
        public void GivenReviewDescriptionWithoutRating_WhenFindFirstRatingOrDefaultIsCalled_ThenDefaultMessageIsReturned()
        {
            const string descriptionString = @"who random0934j/49f test 305/1034 asg4b 1/10. sdf3/10 5//10";
            const string expectedRating = "rating not found";
            var descriptionScanner = new ReviewDescriptionScanner();
            var actualRating = descriptionScanner.FindFirstRatingOrDefault(descriptionString);

            Assert.AreEqual(expectedRating, actualRating);
        }
    }
}
