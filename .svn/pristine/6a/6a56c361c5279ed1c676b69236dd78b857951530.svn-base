using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class TagNewsDao : BaseModel<TagNewsObject>
    {
        /*
         * DAO TagNews
         * NgocNB - 12102016
         */

        /*
         * Lấy all tag
         * NgocNB - 12102016
         */
        public override List<TagNewsObject> getAllElements()
        {
            List<TagNewsObject> lisRs = new List<TagNewsObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_TagNews_GetAll();

                foreach (var objTag in lisGet)
                {
                    lisRs.Add(new TagNewsObject()
                    {
                        TagNewsId = objTag.TagNewsId,
                        TagNewsName = objTag.TagNewsName
                    });
                }
            }

            return lisRs;
        }
        public  List<TagNewsObject> getByNewsId(Guid newsId)
        {
            List<TagNewsObject> lisRs = new List<TagNewsObject>();

            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_TagNews_GetByNewsId(newsId);

                foreach (var objTag in lisGet)
                {
                    lisRs.Add(new TagNewsObject()
                    {
                        TagNewsId = objTag.TagNewsId,
                        TagNewsName = objTag.TagNewsName
                    });
                }
            }

            return lisRs;
        }
    }
}
