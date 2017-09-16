using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class VideoSubCategoryObject
    {
        public Guid VideoSubCategoryID { get; set; }
        public string VideoSubCategoryName { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int TotalVideo { get; set; }
        public bool IsDeleted { get; set; }
        public AccountObject Account { get; set; }
    }
}
