using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoCommentReplyLikeDao : BaseModel<VideoCommentReplyLikeObject>
    {
        public void Insert(VideoCommentReplyLikeObject objLike)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCommentReplyLike_Insert(objLike.VideoCommentReplyLikeId, objLike.VideoCommentReplyId, objLike.LikedBy, objLike.CreatedTime);
        }
        public void Delete(VideoCommentReplyLikeObject objLike)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            m_objDb.WEB_IMIC_SP_VideoCommentReplyLike_Delete(objLike.VideoCommentReplyId, objLike.LikedBy);
        }
        public bool checkUserLike(Guid videoCommentReplyID, Guid userID)
        {
            WebIMicEntities m_objDb = new WebIMicEntities();
            foreach (var item in m_objDb.WEB_IMIC_SP_VideoCommentReplyLike_CheckUserLike(videoCommentReplyID, userID))
            {
                if (item.Value > 0) return true;
            }
            return false;
        }
    }
}
