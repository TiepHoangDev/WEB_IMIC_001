using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class ExperiencerBcl : BaseController<ExperiencerObject>
    {
        // Ngocnb 02112016 get all chuyen gia
        public override List<ExperiencerObject> execOfGetAllElements()
        {
            return new ExperiencerDao().getAllElements();
        }



        public bool ExperiencerInsert(ExperiencerObject objEx)
        {
            return new ExperiencerDao().ExperiencerInsert(objEx);

        }
    }
}
