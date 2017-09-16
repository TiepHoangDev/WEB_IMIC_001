using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;


namespace WCF.DataAccessLayer.Daos
{
    public class WelcomePageDAO : BaseModel<WelcomePageObject>
    {
        public override List<WelcomePageObject> getAllElements()
        {
            List<WelcomePageObject> lisWPO = new List<WelcomePageObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_WelcomePage_getAll().ToList();
                foreach (var item in lisTemp)
                {
                    WelcomePageObject objWP = new WelcomePageObject();

                    objWP.WelcomeId = item.WelcomeId;
                    objWP.CompanyLogo = item.CompanyLogo;
                    objWP.CompanyName = item.CompanyName;
                    objWP.CompanySlogan = item.CompanySlogan;
                    objWP.HomeTextHead = item.HomeTextHead;
                    objWP.HomeTextDescription = item.HomeTextDescription;
                    objWP.Hotline = item.Hotline;
                    objWP.ImageShotcut = item.ImageShotcut;
                    objWP.IsDeleted = item.IsDeleted;
                    objWP.ModifiedBy = item.ModifiedBy;
                    objWP.ModifiedTime = item.ModifiedTime;
                    objWP.VideoLink = item.VideoLink;
                    objWP.Mail = item.Mail;

                    lisWPO.Add(objWP);
                }
            }
            return lisWPO;
        }
    }
}
