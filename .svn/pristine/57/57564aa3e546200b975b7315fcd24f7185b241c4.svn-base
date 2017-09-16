using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoCommentLikeDao : BaseModel<VideoCommentLikeObject>
    {
        public void Insert(VideoCommentLikeObject objLike)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCommentLike_Insert(objLike.VideoCommentLikeId, objLike.VideoCommentId, objLike.LikeBy, objLike.CreatedTime);
        }
        public void Delete(VideoCommentLikeObject objLike)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCommentLike_Delete(objLike.VideoCommentId, objLike.LikeBy);
        }
        public bool checkUserLike(Guid videoCommentID, Guid userID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            foreach (var item in m_objDb.WEB_IMIC_SP_VideoCommentLike_CheckUserLike(videoCommentID, userID))
            {
                if (item.Value > 0) return true;
            }
            return false;
        }
    }
}
