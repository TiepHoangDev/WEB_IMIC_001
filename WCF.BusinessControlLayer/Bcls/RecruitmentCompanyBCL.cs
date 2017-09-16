using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecruitmentCompanyBCL
    {
        public List<RecruitmentCompanyObject> Get()
        {
            return new RecruitmentCompanyDao().GetAll();
        }
        public RecruitmentCompanyObject getElementByID(Guid id)
        {
            return new RecruitmentCompanyDao().GetByCompanyId(id);
        }
        public void addElement(RecruitmentCompanyObject objCom)
        {
            new RecruitmentCompanyDao().Insert(objCom);
        }
        public void updateElement(RecruitmentCompanyObject objCom)
        {
            new RecruitmentCompanyDao().Update(objCom);
        }
        public void deleteElement(Guid id)
        {
            new RecruitmentCompanyDao().Delete(id);
        }
    }
}
