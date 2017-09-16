using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class TagDao:BaseModel<TagObject>
    {
        public List<TagObject> getElemetByMenuId(byte id)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<TagObject> lisTag = new List<TagObject>();
            foreach (var item in db.WEB_IMIC_SP_Tag_GetByMenu(id))
            {
                TagObject objTag = new TagObject();
                objTag.TagId = item.TagId;
                objTag.TagName = item.TagName;
                objTag.MenuId = (byte)item.MenuId;
                lisTag.Add(objTag);
            }
            return lisTag;
        }
        public List<TagObject> getTagByPostId(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<TagObject> lisTag = new List<TagObject>();
            foreach (var item in db.WEB_IMIC_SP_Tag_GetByPostId(id))
            {
                TagObject objTag = new TagObject();
                objTag.TagId = item.TagId;
                objTag.TagName = item.TagName;
                objTag.MenuId = (byte)item.MenuId;
                lisTag.Add(objTag);
            }
            return lisTag;
        }
        public TagObject getByID(Guid Id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_Tag_GetById(Id))
            {
                TagObject objTag = new TagObject();
                objTag.TagId = (Guid)item.TagId;
                objTag.TagName = item.TagName;
                objTag.MenuId = (byte)item.MenuId;
                return objTag;
            }
            return null;
        }
        public bool CheckNameExisted(string TagName,byte MenuId)
        {
            WebIMicEntities db = new WebIMicEntities();
            if (db.WEB_IMIC_SP_Tag_CHECKNAME(TagName,MenuId).ToList()[0] > 0)
                return true;
            return false;
        }
        public void addElement(TagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_Tag_INSERT(objTag.TagId, objTag.TagName, objTag.MenuId);
        }
        public void updateElement(TagObject objTag)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_Tag_UPDATE(objTag.TagId, objTag.TagName, objTag.MenuId);
        }
        public void deleteElement(Guid id)
        {
            new WebIMicEntities().WEB_IMIC_SP_Tag_DELETE(id);
        }
    }
}
