using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class IntroduceServiceDao : BaseModel<IntroduceServiceObject>
    {
        public override List<IntroduceServiceObject> getAllElements()
        {
            List<IntroduceServiceObject> lisIS = new List<IntroduceServiceObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_IntroduceService_GetAll().ToList();
                foreach (var item in lisTemp)
                {
                    IntroduceServiceObject objIS = new IntroduceServiceObject();

                    objIS.IntroduceServiceId = item.IntroduceServiceId;
                    objIS.LinkToService = item.LinkToService;
                    objIS.IsDeleted = item.IsDeleted;
                    objIS.ModifiedBy = item.ModifiedBy;
                    objIS.ModifiedTime = item.ModifiedTime;
                    objIS.Content1 = item.Content1;
                    objIS.Content2 = item.Content2;
                    objIS.Content3 = item.Content3;
                    objIS.Content4 = item.Content4;
                    objIS.RankToShow = item.RankToShow;
                    objIS.ServiceName = item.ServiceName;
                    objIS.ServiceImage = item.ServiceImage;
                    

                    lisIS.Add(objIS);
                }

            }
            return lisIS;
        }
        public bool ServiceUpdate(IntroduceServiceObject objS)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_IntroduceService_Update(
                    objS.IntroduceServiceId,
                    objS.ServiceName,
                    objS.LinkToService,
                    objS.Content1,
                    objS.Content2,
                    objS.Content3,
                    objS.Content4,
                    objS.ServiceImage,
                    objS.RankToShow,
                    objS.IsDeleted,
                    objS.ModifiedBy,
                    DateTime.Now
 
                    );
            }
            return true;
        }
    }
}
