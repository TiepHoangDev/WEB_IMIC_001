using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class RecruitmentBannerObject
    {
        public System.Guid HomeBannerId { get; set; }
        public string ImageLink { get; set; }
        public string ImageAlt { get; set; }
        public string h3text { get; set; }
        public string h4text { get; set; }
        public string pTopText { get; set; }
        public string pMidText { get; set; }
        public string pBotText { get; set; }
        public Nullable<byte> Rank { get; set; }
    }
}
