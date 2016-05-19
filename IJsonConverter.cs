using System.Collections.Generic;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public interface IJsonConverter
    {
        List<ReviewDatum> ConvertJsonToReviewDataList();
    }
}
