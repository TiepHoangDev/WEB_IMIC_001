using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class TechLinkObject
    {
        public System.Guid TechLinkId { get; set; }
        public string TechLinkTitle { get; set; }
        public string Title1 { get; set; }
        public string Sumary1 { get; set; }
        public string Title2 { get; set; }
        public string Sumary2 { get; set; }
        public string TechLinkUrl { get; set; }
        public string TechLinkImage { get; set; }
        public Nullable<int> Number1 { get; set; }
        public Nullable<int> Number2 { get; set; }
        public Nullable<byte> Rank { get; set; }
    }
}
