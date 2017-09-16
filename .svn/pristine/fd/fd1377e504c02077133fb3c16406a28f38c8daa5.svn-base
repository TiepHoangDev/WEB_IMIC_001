using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class SourcePageBcl
    {
       public SourcePageObject GetAll()
       {
           return  new SourcePageDao().GetAll();
       }

       public void SourcePageUpdate(SourcePageObject obj)
       {
           new SourcePageDao().SourceUpdate(obj);
       }
    }
}
