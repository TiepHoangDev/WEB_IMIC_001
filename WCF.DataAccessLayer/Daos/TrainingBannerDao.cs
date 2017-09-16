using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class TrainingBannerDao
    {
        /*
         * Xử lý banner trang đào tạo
         * NgocNB - 05102016
         */

        private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Lấy các banner để hiển thị
         * NgocNB - 05102016
         */
        public static List<TrainingBannerObject> GetBannersToShow()
        {
            var lisGet = m_objDb.WEB_IMIC_SP_TrainingBanner_GetToShow().ToList();

            List<TrainingBannerObject> lisRs = new List<TrainingBannerObject>();

            foreach (var q in lisGet)
            {
                lisRs.Add(new TrainingBannerObject
                {
                    TrainingBannerId = q.TrainingBannerId,
                    BannerLinkTo = q.BannerLinkTo,
                    BannerlmageBackground = q.BannerlmageBackground,
                    BannerSologan = q.BannerSlogan,
                    BannerSumary = q.BannerSumary,
                    BannerTitle = q.BannerTitle,
                    ModifiedBy = q.ModifiedBy,
                    ModifiedTime = "" + q.ModifiedTime,
                    RankToShow = q.RankToShow
                });
            }

            return lisRs;
        }
    }
}