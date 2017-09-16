using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TagObject
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public byte MenuId { get; set; }
    }
}
