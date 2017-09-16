using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class RegisterDetailObject
    {
        public System.Guid RegisterDetailId { get; set; }
        public Nullable<System.Guid> ClassId { get; set; }
        public Nullable<System.Guid> RegisterPersonId { get; set; }
        public string Message { get; set; }
        public string Comment { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<bool> IsSeen { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.Guid> CourseId { get; set; }

        public OpenClassObject OpenClass { get; set; }
        public RegisterPersonObject RegisterPerson { get; set; }
        public CourseObject Course { get; set; }

    }
}
