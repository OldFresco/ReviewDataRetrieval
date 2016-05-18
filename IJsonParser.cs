using ReviewDataRetrieval.Models;
using System.Collections.Generic;

namespace ReviewDataRetrieval
{
    public interface IJsonParser
    {
        List<ReviewData> ParseJsonData();
    }
}
