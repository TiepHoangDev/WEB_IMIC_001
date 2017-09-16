using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoBannerDao : BaseModel<VideoBannerObject>
    {
        private static WebIMicEntities m_objDb = new WebIMicEntities();

        public List<VideoBannerObject> getForView()
        {
            var lisGet = m_objDb.WEB_IMIC_SP_VideoBanner_GetAll().ToList();

            List<VideoBannerObject> lisRs = new List<VideoBannerObject>();

            foreach (var item in lisGet)
            {
                VideoBannerObject objBanner = new VideoBannerObject();
                objBanner.VideoBannerId = item.VideoBannerId;
                objBanner.Bannerlmage = item.Bannerlmage + "";
                objBanner.BannerLinkTo = item.BannerLinkTo + "";
                objBanner.ModifiedBy = item.ModifiedBy.GetValueOrDefault();
                objBanner.ModifiedTime = item.ModifiedTime.GetValueOrDefault();
                objBanner.IsDeleted = item.IsDeleted;
                AccountObject objAcc = new AccountObject();
                objAcc.Username = item.Username;
                objBanner.Account = objAcc;
                lisRs.Add(objBanner);
            }

            return lisRs;
        }
    }
}
