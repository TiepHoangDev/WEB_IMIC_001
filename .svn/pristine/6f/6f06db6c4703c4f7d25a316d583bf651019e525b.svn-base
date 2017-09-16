using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoLikeDao : BaseModel<VideoLikeObject>
    {
        private static WebIMicEntities m_objDb = new WebIMicEntities();
        public void Insert(VideoLikeObject objLike)
        {
            m_objDb.WEB_IMIC_SP_VideoLike_Insert(objLike.VideoLikeId, objLike.VideoId, objLike.LikeBy, objLike.CreatedTime);
        }
        public void Delete(Guid VideoId, Guid LikeBy)
        {
            m_objDb.WEB_IMIC_SP_VideoLike_Delete(VideoId, LikeBy);
        }
        public bool checkUserLike(Guid videoID, Guid userID)
        {
            foreach (var item in m_objDb.WEB_IMIC_SP_VideoLike_CheckUserLike(videoID, userID))
            {
                if (item.Value > 0) return true;
            }
            return false;
        }
    }
}
