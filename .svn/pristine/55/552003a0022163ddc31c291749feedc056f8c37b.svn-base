using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class IntroduceMissionDao : BaseModel<IntroduceMissionObject>
    {
        public override List<IntroduceMissionObject> getAllElements()
        {
            List<IntroduceMissionObject> lisIM = new List<IntroduceMissionObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_IntroduceMission_GetAll().ToList();
                foreach (var item in lisTemp)
                {
                    IntroduceMissionObject objIM = new IntroduceMissionObject();
                    
                    objIM.IntroduceMissionld = item.IntroduceMissionld;
                    objIM.Link = item.Link;
                    objIM.IsDeleted = item.IsDeleted;
                    objIM.ModifiedBy = item.ModifiedBy;
                    objIM.ModifiedTime = item.ModifiedTime;
                    objIM.Content1 = item.Content1;
                    objIM.Content2 = item.Content2;
                    objIM.Content3 = item.Content3;
                    objIM.RankToShow = item.RankToShow;
                    objIM.Title = item.Title;

                    lisIM.Add(objIM);
                }
                
            }
            return lisIM;
        }

        public bool MissionInsert(IntroduceMissionObject objM)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_IntroduceMission_Update(
                    objM.IntroduceMissionld,
                    objM.Link,
                    objM.Title,
                    objM.Content1,
                    objM.Content2,
                    objM.Content3,
                    objM.RankToShow,
                    objM.ModifiedBy,
                    DateTime.Now
                    );
            }
            return true;
        }
    }
}
