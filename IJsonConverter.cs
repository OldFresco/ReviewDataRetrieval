using ReviewDataRetrieval.Models;
using System.Collections.Generic;

namespace ReviewDataRetrieval
{
    public interface IJsonConverter
    {
        List<ReviewData> ConvertJsonToReviewDataList();
    }
}
