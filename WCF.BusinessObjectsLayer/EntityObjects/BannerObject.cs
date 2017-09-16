using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class BannerObject
    {
        public System.Guid BannerId { get; set; }
        public Nullable<bool> FlagImage { get; set; }
        public Nullable<byte> MenuId { get; set; }
        public string ImageLink { get; set; }
        public string ImageAlt { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public Nullable<int> Rank { get; set; }
    }
}
