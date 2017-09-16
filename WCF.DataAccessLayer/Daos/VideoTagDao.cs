using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class VideoTagDao : BaseModel<VideoTagObject>
    {
        public List<VideoTagObject> getElements()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<VideoTagObject> lisRs = new List<VideoTagObject>();
            foreach (var item in db.WEB_IMIC_SP_VideoTag_GETALL())
            {
                VideoTagObject objTag = new VideoTagObject();
                objTag.VideoTagId = (Guid)item.VideoTagId;
                objTag.VideoTagName = item.VideoTagName;
                objTag.TotalOfVideos = (int)item.TotalOfVideos;
                lisRs.Add(objTag);
            }
            return lisRs;

        }
        public List<VideoTagObject> getByVideoCode(string VideoCodeNumber)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<VideoTagObject> lisRs = new List<VideoTagObject>();
            foreach (var item in db.WEB_IMIC_SP_VideoTag_GETBYVIDEOCODE(VideoCodeNumber))
            {
                VideoTagObject objTag = new VideoTagObject();
                objTag.VideoTagId = (Guid)item.VideoTagId;
                objTag.VideoTagName = item.VideoTagName;
                lisRs.Add(objTag);
            }
            return lisRs;
        }

        public VideoTagObject getByID(Guid Id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_VideoTag_GETBYID(Id))
            {
                VideoTagObject objTag = new VideoTagObject();
                objTag.VideoTagId = (Guid)item.VideoTagId;
                objTag.VideoTagName = item.VideoTagName;
                objTag.TotalOfVideos = (int)item.TotalOfVideos;
                return objTag;
            }
            return null;

        }
        public bool CheckNameExisted(string TagName)
        {
            WebIMicEntities db = new WebIMicEntities();
            if (db.WEB_IMIC_SP_VideoTag_CHECKNAME(TagName).ToList()[0] > 0)
                return true;
            return false;
        }
        public void addElement(VideoTagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_VideoTag_INSERT(objTag.VideoTagId, objTag.VideoTagName, objTag.TotalOfVideos);
        }
        public void updateElement(VideoTagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_VideoTag_UPDATE(objTag.VideoTagId, objTag.VideoTagName, objTag.TotalOfVideos);
        }
        public void deleteElement(Guid id)
        {
            new WebIMicEntities().WEB_IMIC_SP_VideoTag_DELETE(id);
        }
    }
}
