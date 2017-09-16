using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class ProposeObject
    {
        public System.Guid ProposeId { get; set; }
        public string ProposeName { get; set; }
        public int No { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.Guid> RegisterBy { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
        public Nullable<bool> IsRegister { get; set; }
        public AccountObject objUser { get; set; }
    }
}
