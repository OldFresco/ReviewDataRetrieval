using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedleDropReviewDataMiner
{
    public class ReviewType
    {
        public enum ValidReviewTypes
        {
            ALBUM = 1, MIXTAPE = 0
        }

        public bool Validate(string reviewTitle)
        {
            var words = reviewTitle.Split(' ');
        }
    }
}
