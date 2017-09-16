using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class IntroduceBannerDao : BaseModel<IntroduceBannerObject>
    {
        public override List<IntroduceBannerObject> getAllElements()
        {
            List<IntroduceBannerObject> lisIB = new List<IntroduceBannerObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_IntroduceBanner_GetAll().ToList();
                foreach (var item in lisTemp)
                {
                   IntroduceBannerObject objBO = new IntroduceBannerObject();
                    
                    objBO.IntroduceBanerld = item.IntroduceBanerld;
                    objBO.Bannerlmage = item.Bannerlmage;
                    objBO.IsDeleted = item.IsDeleted;
                    objBO.ModifiedBy = item.ModifiedBy;
                    objBO.ModifiedTime = item.ModifiedTime;
                    objBO.BannerAlt = item.BannerAlt;
                    objBO.Content1 = item.Content1;
                    objBO.Content2 = item.Content2;
                    objBO.Content3 = item.Content3;
                    objBO.Content4 = item.Content4;
                    objBO.Content5 = item.Content5;
                    objBO.RankToShow = item.RankToShow;
                    objBO.TitleBanner = item.TitleBanner;
                    objBO.Account = new AccountObject();
                    objBO.Account.Username = item.Username;                                        
                    lisIB.Add(objBO);
                }
                
            }
            return lisIB;
           
        }

        public  IntroduceBannerObject getElementsById(Guid id)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            foreach (var item in m_objDb.WEB_IMIC_SP_IntroduceBanner_GetById(id))
            {
                IntroduceBannerObject objBO = new IntroduceBannerObject();
                objBO.IntroduceBanerld = item.IntroduceBanerld;
                objBO.Bannerlmage = item.Bannerlmage;
                objBO.IsDeleted = item.IsDeleted;
                objBO.ModifiedBy = item.ModifiedBy;
                objBO.ModifiedTime = item.ModifiedTime;
                objBO.BannerAlt = item.BannerAlt;
                objBO.Content1 = item.Content1;
                objBO.Content2 = item.Content2;
                objBO.Content3 = item.Content3;
                objBO.Content4 = item.Content4;
                objBO.Content5 = item.Content5;
                objBO.RankToShow = item.RankToShow;
                objBO.TitleBanner = item.TitleBanner;

                return objBO;
            }
            return null;
        }

        // Ngocnb - 31102016
        public bool BannerInsert(IntroduceBannerObject obj)
        {
            using (var db = new WebIMicEntities())
            {
                obj.IntroduceBanerld = Guid.NewGuid();

                db.WEB_IMIC_SP_IntroduceBanner_Update(
                    obj.IntroduceBanerld,
                   obj.Bannerlmage,
                    obj.BannerAlt,
                    obj.IsDeleted,
                   obj.TitleBanner,
                   obj.Content1,
                    obj.Content2,
                    obj.Content3,
                   obj.Content4,
                    obj.Content5,
                   obj.RankToShow,
                    obj.ModifiedBy,
                   DateTime.Now,
                   false);
            }

            return true;
            
        }

        public bool BannerUpdate(IntroduceBannerObject obj)
        {
           using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_IntroduceBanner_Update(
                    obj.IntroduceBanerld,
                    obj.Bannerlmage,
                   obj.BannerAlt,
                   obj.IsDeleted,
                   obj.TitleBanner,
                    obj.Content1,
                   obj.Content2,
                    obj.Content3,
                   obj.Content4,
                   obj.Content5,
                   obj.RankToShow,
                   obj.ModifiedBy,
                   DateTime.Now,
                   true);
           }

            return true;
           
        }

        public bool BannerDelete(Guid bannerId)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_IntroduceBanner_Delete(bannerId);
            }
            return true;
        }
    }
}
