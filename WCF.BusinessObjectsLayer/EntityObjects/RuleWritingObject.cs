using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class RuleWritingObject
    {
       public int ID { get; set; }

       public string Title
       {
           get; set;
           
       }
       public string Content { get; set; }
    }
}
