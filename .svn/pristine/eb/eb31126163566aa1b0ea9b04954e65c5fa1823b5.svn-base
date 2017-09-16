using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.DataAccessLayer.Models;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.DataAccessLayer.Daos
{
    public class IntroduceEduProgramDao : BaseModel<IntroduceEduProgramObject>
    {
        public override List<IntroduceEduProgramObject> getAllElements()
        {
            List<IntroduceEduProgramObject> lisIEP = new List<IntroduceEduProgramObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_IntroduceEduProgram_GetAll().ToList();
                foreach (var item in lisTemp)
                {
                    IntroduceEduProgramObject objEP = new IntroduceEduProgramObject();

                    objEP.IntroduceEPId = (byte)item.IntroduceEPId;
                    objEP.Line1 = item.Line1;
                    objEP.Line2 = item.Line2;
                    objEP.Line3 = item.Line3;
                    objEP.Line4 = item.Line4;
                    objEP.Line5 = item.Line5;
                    objEP.Line6 = item.Line6;
                    objEP.rank = (byte)item.rank;
                    objEP.Title = item.Title;

                    lisIEP.Add(objEP);
                }

            }
            return lisIEP;
        }

        public bool EduProgramUpdate(IntroduceEduProgramObject obj)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_IntroduceEduProgram_Update(
                    obj.IntroduceEPId,
                    obj.Title,
                    obj.Line1,
                    obj.Line2,
                    obj.Line3,
                    obj.Line4,
                    obj.Line5,
                    obj.Line6,
                    obj.rank,                    
                    true);
            }

            return true;
        }
    }
}
