using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoTagDetailDao : BaseModel<VideoTagDetailObject>
    {
        public void addElement(VideoTagDetailObject objDetail)
        {
            new WebIMicEntities().WEB_IMIC_SP_VideoTagDetail_INSERT(objDetail.VideoTagDetailId, objDetail.VideoId, objDetail.VideoTagId);
        }
        public void deleteElementByVideo(Guid VideoId)
        {
            new WebIMicEntities().WEB_IMIC_SP_VideoTagDetail_DELETEBYVIDEOID(VideoId);
        }
    }
}
