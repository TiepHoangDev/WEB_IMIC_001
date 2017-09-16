using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class RecJobDao
    {
       public List<ReJobObject> GetAll()
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstJob = db.WEB_IMIC_SP_Job_GetAll();
           List<ReJobObject> lisObj = new List<ReJobObject>();
           foreach (var item in lstJob)
           {
               ReJobObject obj = new ReJobObject();
               obj.JobId = item.JobId;
               obj.JobTitle = item.JobTitle;
               obj.JobSummary = item.JobSummary;
               obj.JobImage_Link = item.JobImage_Link;
               obj.JobImage_Alt = item.JobImage_Alt;
               obj.Job_Url = item.Job_Url;
               obj.NewsLetterTagId = (Guid) item.NewsLetterTagId;
               obj.objTag = new NewsletterTagObject()
               {
                   NewsletterTagName = item.NewsLetterTagName
               };
               obj.Rank = item.Rank;
               lisObj.Add(obj);
           }
           return lisObj;
       }

       public ReJobObject GetByID(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           var lstJob = db.WEB_IMIC_SP_Job_GetByID(id);
           ReJobObject obj = new ReJobObject();
           foreach (var item in lstJob)
           {
               obj.JobId = item.JobId;
               obj.JobTitle = item.JobTitle;
               obj.JobSummary = item.JobSummary;
               obj.JobImage_Link = item.JobImage_Link;
               obj.JobImage_Alt = item.JobImage_Alt;
               obj.Job_Url = item.Job_Url;
               obj.Rank = item.Rank;
           }
           return obj;
       }

       public void JobInsert(ReJobObject obj)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Job_Insert(obj.JobId, obj.JobTitle, obj.JobSummary, obj.JobImage_Link, obj.JobImage_Alt,
               obj.Job_Url,obj.NewsLetterTagId, obj.Rank);
       }

       public void JobUpdate(ReJobObject obj)
       {

           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Job_Update(obj.JobId, obj.JobTitle, obj.JobSummary, obj.JobImage_Link, obj.JobImage_Alt,
               obj.Job_Url, obj.NewsLetterTagId, obj.Rank);
       }

       public void JobDelete(Guid id)
       {
           WebIMicEntities db = new WebIMicEntities();
           db.WEB_IMIC_SP_Job_Delete(id);
       }
    }
}
