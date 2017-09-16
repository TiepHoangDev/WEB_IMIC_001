using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class VideoTagBcl
    {
        public List<VideoTagObject> getElements()
        {
            return new VideoTagDao().getElements();
        }

        public List<VideoTagObject> getByVideoCode(string VideoCodeNumber)
        {
            return new VideoTagDao().getByVideoCode(VideoCodeNumber);
        }

        public VideoTagObject getByID(Guid VideoTagId)
        {
            return new VideoTagDao().getByID(VideoTagId);
        }

        public bool CheckNameExisted(string TagName)
        {
            return new VideoTagDao().CheckNameExisted(TagName);
        }

        public void addElement(VideoTagObject objTag)
        {
            new VideoTagDao().addElement(objTag);
        }

        public void updateElement(VideoTagObject objTag)
        {
            new VideoTagDao().updateElement(objTag);
        }

        public void deleteElement(Guid ProductTagId)
        {
            new VideoTagDao().deleteElement(ProductTagId);
        }
    }
}
