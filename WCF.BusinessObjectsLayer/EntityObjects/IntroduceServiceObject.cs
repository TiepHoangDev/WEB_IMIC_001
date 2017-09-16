using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class IntroduceServiceObject
    {
        public Guid IntroduceServiceId { get; set; }
        public string ServiceName { get; set; }
        public string LinkToService { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Content4 { get; set; }
        public string ServiceImage { get; set; }
        public byte? RankToShow { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }

        public AccountObject Account { get; set; }
    }
}
