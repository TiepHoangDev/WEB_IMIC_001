using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class IntroducePartnerDao : BaseModel<IntroducePartnerObject>
    {
        public override List<IntroducePartnerObject> getAllElements()
        {
            List<IntroducePartnerObject> lisIP = new List<IntroducePartnerObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_IntroducePartner_GetAll().ToList();
                foreach (var item in lisTemp)
                {
                    IntroducePartnerObject objIP = new IntroducePartnerObject();
                    
                    objIP.IntroducePartnerId = item.IntroducePartnerId;
                    objIP.PartnerLinkTo = item.PartnerLinkTo;
                    objIP.ModifiedBy = item.ModifiedBy;
                    objIP.ModifiedTime = item.ModifiedTime;
                    objIP.PartnerLogo = item.PartnerLogo;
                    objIP.PartnerName = item.PartnerName;
                    objIP.RankToShow = item.RankToShow;
                    objIP.IsDeleted = item.IsDeleted;

                    lisIP.Add(objIP);
                }
            }

            return lisIP;
        }
    }
}
