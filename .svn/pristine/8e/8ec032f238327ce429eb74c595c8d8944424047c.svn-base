using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
   public class RecruitmentTitleBcl
    {
       public RecruitmentTitleObject GetAll()
       {
           return new RecruitmentTitleDao().GetByID();
       }

       public void RecruimentTitleUpdate(RecruitmentTitleObject obj)
       {
           new RecruitmentTitleDao().RecruimnetTitleUpdate(obj);
       }
    }
}
