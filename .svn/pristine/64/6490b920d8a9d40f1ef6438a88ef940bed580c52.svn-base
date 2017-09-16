using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class SourcePageDao
    {
        public SourcePageObject GetAll()
        {
            WebIMicEntities db = new WebIMicEntities();
            SourcePageObject obj =  new SourcePageObject();
            foreach (var item in db.WEB_IMIC_SP_SourcePage_GetAll())
            {
                obj.SourceId = item.SourceId;
                obj.LessonSource = item.LessonSource;
                obj.TechSource = item.TechSource;
                obj.RecruitSource = item.RecruitSource;
            }
            return obj;
        }

        public void SourceUpdate( SourcePageObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_SourcePage_Update(obj.TechSource, obj.LessonSource, obj.RecruitSource);
        }
    }
}
