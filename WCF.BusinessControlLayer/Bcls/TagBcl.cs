using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TagBcl
    {
        public List<TagObject> getElementByMenuId(byte id)
        {
            return new TagDao().getElemetByMenuId(id);
        }
        public List<TagObject> getTagByPostId(Guid id)
        {
            return new TagDao().getTagByPostId(id);
        }
        public TagObject getById(Guid Id)
        {
            return new TagDao().getByID(Id);
        }
        public bool CheckNameExisted(string TagName,byte MenuId)
        {
            return new TagDao().CheckNameExisted(TagName,MenuId);
        }

        public void addElement(TagObject objTag)
        {
            new TagDao().addElement(objTag);
        }

        public void updateElement(TagObject objTag)
        {
            new TagDao().updateElement(objTag);
        }

        public void deleteElement(Guid TagId)
        {
            new TagDao().deleteElement(TagId);
        }
    }
}
