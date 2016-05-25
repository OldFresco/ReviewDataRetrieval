using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedleDropReviewDataMiner
{
    public class UIBannerSection
    {
        public int TopPaddingSize { get; set; }
        public int BottomPaddingSize { get; set; }
        public string BannerContent { get; set; }
        public bool BannerDivisorMode { get; set; }

        public UIBannerSection(int topPadding, int bottomPadding, string content, bool divisorMode)
        {
            TopPaddingSize = topPadding;
            BottomPaddingSize = bottomPadding;
            BannerContent = content;
            BannerDivisorMode = divisorMode;
        }

    }
}