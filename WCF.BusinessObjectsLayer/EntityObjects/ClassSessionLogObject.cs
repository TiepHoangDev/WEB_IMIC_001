using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class ClassSessionLogObject
    {
        public System.Guid ClassSessionLogId { get; set; }
        public Nullable<System.Guid> ClassId { get; set; }
        public Nullable<System.Guid> TeacherAccountId { get; set; }
        public Nullable<System.DateTime> OnDate { get; set; }
        public string LessonContent { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActived { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public ClassObject objClass { get; set; }
        public AccountObject objAcc { get; set; }
    }
}
