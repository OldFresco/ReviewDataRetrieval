using System;
using System.Net.Http;
using NeedleDrop.DataMiner.UI;

namespace NeedleDropReviewDataMiner
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var dataMiner = new ReviewRatingDataMiner(Properties.Settings.Default.playlistId,"/filePath.csv");
            dataMiner.Execute();
        }
    }
}
