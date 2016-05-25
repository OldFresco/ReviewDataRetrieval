using System.Collections.Generic;
using NeedleDropReviewDataMiner.Models;

namespace NeedleDropReviewDataMiner
{
    public interface IJsonConverter
    {
        List<ReviewDatum> ConvertJsonToReviewDataList();
    }
}
