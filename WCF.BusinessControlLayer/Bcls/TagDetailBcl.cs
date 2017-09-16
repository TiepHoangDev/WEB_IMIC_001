using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TagDetailBcl
    {
        public void addElement(TagDetailObject objDetail)
        {
            new TagDetailDao().addElement(objDetail);
        }

        public void deleteElementByPost(Guid Id)
        {
            new TagDetailDao().deleteElementByPost(Id);
        }
    }
}
