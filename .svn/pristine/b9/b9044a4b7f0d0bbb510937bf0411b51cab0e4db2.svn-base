using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class RecruitmentTitleDao
    {
       public RecruitmentTitleObject GetByID()
       {
           WebIMicEntities db =new WebIMicEntities();
           var lstTitle = db.WEB_IMIC_SP_RecruitmentTitle_GetAll();
           RecruitmentTitleObject obj = new RecruitmentTitleObject();
           foreach (var item in lstTitle)
           {
               obj.RecruitmentTitleId = item.RecruitmentTitleId;
               obj.Title1 = item.Title1;
               obj.Summary1 = item.Summary1;
               obj.Title2 = item.Title2;
               obj.Summary2 = item.Summary2;
               obj.Title3 = item.Title3;
               obj.Summary3 = item.Summary3;
           }
           return obj;
       }

       public void RecruimnetTitleUpdate(RecruitmentTitleObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_RecruitmentTitle_Update(obj.RecruitmentTitleId, obj.Title1, obj.Summary1, obj.Title2,
               obj.Summary2, obj.Title3, obj.Summary3);
       }
    }
}
