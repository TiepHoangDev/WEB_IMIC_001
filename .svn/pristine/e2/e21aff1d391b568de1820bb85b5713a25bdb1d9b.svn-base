using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
  public  class RuleWritingDao
    {
      public RuleWritingObject GetAll()
      {
          WebIMicEntities db = new WebIMicEntities();
          RuleWritingObject obj = new RuleWritingObject();
          foreach (var item in db.WEB_IMIC_SP_RuleWriting_GEtAll())
          {
              obj.ID = item.ID;
              obj.Title = item.Title;
              obj.Content = item.Content;
          }
          return obj;
      }

      public void RuleUpate(RuleWritingObject obj)
      {
          WebIMicEntities db =new WebIMicEntities();
          db.WEB_IMIC_SP_RuleWriting_Update(obj.Title, obj.Content);
      }
    }
}
