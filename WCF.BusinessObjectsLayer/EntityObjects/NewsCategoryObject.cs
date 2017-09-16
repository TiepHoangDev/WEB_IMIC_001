using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class NewsCategoryObject
    {
        public Guid NewsCategoryId { get; set; }
        public string NewsCategoryName { get; set; }
        public string CategoryImage { get; set; }
        public Guid ModifiedBy { get; set; }
        public string ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public int NCCode { get; set; }

        public AccountObject ModifiedPerson { get; set; }
        public List<NewsObject> ListNews { get; set; }
    }
}
