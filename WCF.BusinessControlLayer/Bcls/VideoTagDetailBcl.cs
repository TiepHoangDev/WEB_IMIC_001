using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class VideoTagDetailBcl
    {
        public void addElement(VideoTagDetailObject objDetail)
        {
            new VideoTagDetailDao().addElement(objDetail);
        }

        public void deleteElementByVideo(Guid VideoId)
        {
            new VideoTagDetailDao().deleteElementByVideo(VideoId);
        }
    }
}
