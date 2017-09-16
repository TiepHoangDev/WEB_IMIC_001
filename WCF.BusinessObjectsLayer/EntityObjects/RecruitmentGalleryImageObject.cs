using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
  public  class RecruitmentGalleryImageObject
    {
        public System.Guid GalleryImageId { get; set; }
        public string ImageTitle { get; set; }
        public string ImageSummary { get; set; }
        public string Image_Link { get; set; }
        public string Image_Alt { get; set; }
        public Nullable<byte> Rank { get; set; }
    }
}
