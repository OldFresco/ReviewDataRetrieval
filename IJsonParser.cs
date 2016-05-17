using System.Collections.Generic;
using ReviewDataRetrieval.Models;

namespace ReviewDataRetrieval
{
    public interface IJsonParser
    {
        List<ReviewData> ParseJsonData();
    }
}
