using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RecruitmentBannerDao
    {
        public List<RecruitmentBannerObject> GetAll()
        {
            WebIMicEntities db = new WebIMicEntities();
            var lstBanner = db.WEB_IMIC_SP_RecruitmentBanner_GetAll();
            List<RecruitmentBannerObject> lisObj = new List<RecruitmentBannerObject>();
            foreach (var item in lstBanner)
            {
                RecruitmentBannerObject obj = new RecruitmentBannerObject();
                obj.HomeBannerId = item.HomeBannerId;
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

        public RecruitmentBannerObject GetByID(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            var lstBanner = db.WEB_IMIC_SP_RecruitmentBanner_GetByID(id);
            RecruitmentBannerObject obj = new RecruitmentBannerObject();
            foreach (var item in lstBanner)
            {
                obj.HomeBannerId = item.HomeBannerId;
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

        public void BannerInsert(RecruitmentBannerObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_RecruitmentBanner_Insert(obj.HomeBannerId, obj.ImageLink, obj.ImageAlt, obj.h3text,
                obj.h4text, obj.pTopText, obj.pMidText, obj.pBotText, obj.Rank);
        }

        public void BannerUpdate(RecruitmentBannerObject obj)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_RecruitmentBanner_Update(obj.HomeBannerId, obj.ImageLink, obj.ImageAlt, obj.h3text,
               obj.h4text, obj.pTopText, obj.pMidText, obj.pBotText, obj.Rank);
        }
        public void BannerDelete(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_RecruitmentBanner_Delete(id);
        }
    }
}
