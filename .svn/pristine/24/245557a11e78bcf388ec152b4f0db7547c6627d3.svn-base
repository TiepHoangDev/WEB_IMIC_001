using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecruitmentNewsletterBCL
    {
        public List<RecruitmentNewsletterObject> getElements()
        {
            return new RecruitmentNewsLetterDAO().getElements();
        }
        public RecruitmentNewsletterObject getByCode(long code)
        {
            return new RecruitmentNewsLetterDAO().getByCode(code);
        }
        public RecruitmentNewsletterObject getByID(Guid id)
        {
            return new RecruitmentNewsLetterDAO().getByID(id);
        }
        public List<RecruitmentNewsletterObject> getForPaging(int? code, string query, int start, int length)
        {
            return new RecruitmentNewsLetterDAO().getForPaging(code,query, start, length);
        }
        public List<RecruitmentNewsletterObject> getPopular()
        {
            return new RecruitmentNewsLetterDAO().getPopular();
        }
        public List<RecruitmentNewsletterObject> getRelated(Guid id)
        {
            return new RecruitmentNewsLetterDAO().getRelated(id);
        }
        public void deleteElement(Guid id)
        {
            new RecruitmentNewsLetterDAO().deleteElement(id);
        }
            
        
        public void addElement(RecruitmentNewsletterObject objNew)
        {
            new RecruitmentNewsLetterDAO().addElement(objNew);
        }
        public void updateElement(RecruitmentNewsletterObject objNew)
        {
            new RecruitmentNewsLetterDAO().updateElement(objNew);
        }
        public List<RecruitmentNewsletterObject> getRelated_Category(Guid id)
        {
            return new RecruitmentNewsLetterDAO().getRelated_Category(id);
        }

        public void ApproveNewsLetter(Guid id)
        {
            new RecruitmentNewsLetterDAO().ApproveNewsLetter(id);
        }
    }
}
