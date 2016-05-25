﻿using System;
using System.Net.Http;

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
