using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class ClassSessionDetailObject
    {
        public Guid ClassSessionDetailId { get; set; }
        public Guid ClassId { get; set; }
        public Guid ClassShiftid { get; set; }
        public int ClassWeekdayId { get; set; }
        public bool IsActived { get; set; }
        public DateTime OnDate { get; set; }
        public ClassObject ClassObject { get; set; }
        public ClassShiftObject ClassShiftObject { get; set; }
        public ClassWeekDayObject ClassWeekDayObject { get; set; }
    }
}
