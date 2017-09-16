using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class FacebookUserLikedDao
    {
        public List<FacebookUserLikedObject> GetAllFacebookUserLiked()
        {
            List<FacebookUserLikedObject> lisFL = new List<FacebookUserLikedObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_FacebookUserLiked_getAll().ToList();
                foreach (var item in lisTemp)
                {
                    FacebookUserLikedObject obj = new FacebookUserLikedObject
                    {
                        FacebookUserLikedId = item.FacebookUserLikedId,
                        FacebookAvatar = item.FacebookAvatar,
                        FacebookLink = item.FacebookLink,
                        FacebookName = item.FacebookName,
                        IsDeleted = item.IsDeleted,
                        IsShow = item.IsShow,
                        RankVip = item.RankVip
                    };
                    lisFL.Add(obj);
                }
                
            }
            return lisFL;
        }

        public FacebookUserLikedObject getById(Guid facebookUserLikedId)
        {
            FacebookUserLikedObject objFL;
            using (var dbContext = new WebIMicEntities())
            {
                var item = dbContext.WEB_IMIC_SP_FacebookUserLiked_getById(facebookUserLikedId).FirstOrDefault();
                objFL = new FacebookUserLikedObject
                {
                    FacebookUserLikedId = item.FacebookUserLikedId,
                    FacebookAvatar = item.FacebookAvatar,
                    FacebookLink = item.FacebookLink,
                    FacebookName = item.FacebookName,
                    IsDeleted = item.IsDeleted,
                    IsShow = item.IsShow,
                    RankVip = item.RankVip
                };
            }
            return objFL;
        }

        public bool InsertFacebookUserLiked(FacebookUserLikedObject obj)
        {
            using (var dbContext = new WebIMicEntities())
            {
                dbContext.WEB_IMIC_SP_FacebookUserLiked_Update(Guid.NewGuid(), obj.FacebookAvatar,
                    obj.FacebookName, obj.FacebookLink, false, true, obj.RankVip, false);
            }
            return true;
        }
        public bool UpdateFacebookUserLiked(FacebookUserLikedObject obj)
        {
            using (var dbContext = new WebIMicEntities())
            {
                dbContext.WEB_IMIC_SP_FacebookUserLiked_Update(obj.FacebookUserLikedId, obj.FacebookAvatar,
                    obj.FacebookName, obj.FacebookLink, obj.IsDeleted, obj.IsShow, obj.RankVip, true);
            }
            return true;
        }
        public bool DeleteFacebookUserLiked(Guid fbId)
        {
            using (var dbContext = new WebIMicEntities())
            {
                dbContext.WEB_IMIC_SP_FacebookUserLiked_updateIsDeleted(fbId, true);
            }
            return true;
        }
    }
}
