using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class JobObject
    {
        public System.Guid JobObjectId { get; set; }
        public string JobObjectName { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.Guid> ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }

        public RegisterPersonObject RegisterPerson { get; set; }
    }
}
