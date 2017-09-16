using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class TagDetailDao:BaseModel<TagDetailObject>
    {
        public void addElement(TagDetailObject objDetail)
        {
            new WebIMicEntities().WEB_IMIC_SP_TagDetail_INSERT(objDetail.TagDetailId, objDetail.PostId, objDetail.TagId);
        }
        public void deleteElementByPost(Guid Id)
        {
            new WebIMicEntities().WEB_IMIC_SP_TagDetail_DELETEBYPOSTID(Id);
        }
    }
}
