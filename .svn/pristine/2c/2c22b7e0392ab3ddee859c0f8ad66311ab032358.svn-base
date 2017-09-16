using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
   public class TechBannerDao
    {
        public List<TechBannerObject> GetAll()
        {
            WebIMicEntities db = new WebIMicEntities();
            var lstBanner = db.WEB_IMIC_SP_TechBanner_GetAll();
            List<TechBannerObject> lisObj = new List<TechBannerObject>();
            foreach (var item in lstBanner)
            {
                TechBannerObject obj = new TechBannerObject();
                obj.TechBannerId = item.TechBannerId;
                obj.h3text = item.h3text;
                obj.h4text = item.h4text;
                obj.ImageLink = item.ImageLink;
                obj.ImageAlt = item.ImageAlt;
                obj.pTopText = item.pTopText;
                obj.pMidText = item.pMidText;
                obj.pBotText = item.pBotText;
                obj.Rank = item.Rank;
                lisObj.Add(obj);
            }
            return lisObj;
        }

        public TechBannerObject GetByID(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            var lstBanner = db.WEB_IMIC_SP_TechBanner_GetByID(id);
            TechBannerObject obj = new TechBannerObject();
            foreach (var item in lstBanner)
            {
                obj.TechBannerId = item.TechBannerId;
                obj.h3text = item.h3text;
                obj.h4text = item.h4text;
                obj.ImageLink = item.ImageLink;
                obj.ImageAlt = item.ImageAlt;
                obj.pTopText = item.pTopText;
                obj.pMidText = item.pMidText;
                obj.pBotText = item.pBotText;
                obj.Rank = item.Rank;
            }
            return obj;
        }

        public void BannerInsert(TechBannerObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechBanner_Insert(obj.TechBannerId, obj.ImageLink, obj.ImageAlt, obj.h3text,
                obj.h4text, obj.pTopText, obj.pMidText, obj.pBotText, obj.Rank);
        }

        public void BannerUpdate(TechBannerObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechBanner_Update(obj.TechBannerId, obj.ImageLink, obj.ImageAlt, obj.h3text,
               obj.h4text, obj.pTopText, obj.pMidText, obj.pBotText, obj.Rank);
        }
        public void BannerDelete(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_TechBanner_Delete(id);
        }
    }
}
