using System;

namespace NeedleDropReviewDataMiner
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            var dataMiner = new ReviewRatingDataMiner(Properties.Settings.Default.playlistId);
            dataMiner.Execute();
        }
    }
}
