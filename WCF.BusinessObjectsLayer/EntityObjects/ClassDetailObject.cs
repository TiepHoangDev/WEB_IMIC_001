using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class ClassDetailObject
    {
        public System.Guid ClassDetailId { get; set; }
        public Nullable<System.Guid> DetailUser { get; set; }
        public Nullable<System.Guid> ClassId { get; set; }
        public Nullable<byte> ClassRole { get; set; }
        public string Description { get; set; }
        public ClassObject objClass { get; set; }
        public AccountObject objAcc { get; set; }
    }
}
