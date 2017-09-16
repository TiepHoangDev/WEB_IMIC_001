using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class VideoCategoryObject
    {
        public Guid VideoCategoryId { get; set; }
        public string VideoCategoryName { get; set; }
        public string VideoCategoryIcon { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public AccountObject Account { get; set; }
        public bool IsDeleted { get; set; }
        public int VCCodeNumber { get; set; }
        public int TotalVideo { get; set; }
    }
}
