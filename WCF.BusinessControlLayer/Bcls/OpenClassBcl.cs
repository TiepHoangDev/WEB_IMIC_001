using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class OpenClassBcl:BaseController<OpenClassObject>
    {
        public override List<OpenClassObject> execOfGetAllElements()
        {
            return new OpenClassDao().getAllElements();
        }
        public bool InsertClass(OpenClassObject objOc)
        {
            return new OpenClassDao().InsertClass(objOc);
        }

        public bool UpdateClass(OpenClassObject objOc)
        {
            return new OpenClassDao().UpdateClass(objOc);
        }
        public bool DeleteClass(Guid classId)
        {
            return new OpenClassDao().DeleteClass(classId);
        }
        public List<OpenClassObject> GetAllElementsByTCCodeNumber(int tcCodeNumber)
        {
            return new OpenClassDao().getAllElementsByTCCodeNumber(tcCodeNumber);
        }
        public List<OpenClassObject> GetAllElementsByTrainingCategoryId(Guid TrainingCategoryId)
        {
            return new OpenClassDao().getAllElementsByTrainingCategoryId(TrainingCategoryId);
        }

        public override List<OpenClassObject> execOfGetElementsById(Guid id)
        {
            return new OpenClassDao().getElementsById(id);
        }
        public OpenClassObject GetElementsById(Guid id)
        {
            return new OpenClassDao().getById(id);
        }
        public List<JobObject> GetJobsAll()
        {
            return new JobObjectDao().getAllElements();
        }

        public bool InsertRegister(RegisterDetailObject objReg)
        {
            new RegisterPersonDao().Insert(objReg.RegisterPerson);
            new RegisterDetailDao().Insert(objReg);
            return true;
        }

        public RegisterDetailObject getRegisterById(Guid id)
        {
            return new RegisterDetailDao().getbyID(id);
        }
        public List<RegisterDetailObject> GetRegister_IsSeen(bool isSeen = false)
        {
            List<RegisterDetailObject> lisRD = new RegisterDetailDao().GetRegisterDetail_IsSeen(isSeen);
            OpenClassDao daoOP = new OpenClassDao();
            RegisterPersonDao daoRP = new RegisterPersonDao();
            JobObjectDao daoJO = new JobObjectDao();

            for (int i = 0; i < lisRD.Count(); i++)
            {
                lisRD[i].OpenClass = lisRD[i].ClassId != null ? daoOP.getElementsById((Guid)lisRD[i].ClassId).FirstOrDefault() : null;
                lisRD[i].RegisterPerson = daoRP.GetById((Guid)lisRD[i].RegisterPersonId);
                lisRD[i].RegisterPerson.JobObj = daoJO.GetById((Guid)lisRD[i].RegisterPerson.JobObjectId);
                lisRD[i].Course = lisRD[i].CourseId != null ? new CourseDao().GetCourseObjectByCourseId((Guid) lisRD[i].CourseId).FirstOrDefault() : null;
            }

            return lisRD;
        }

        
        public bool UpdateRegisterDetail(RegisterDetailObject objRD)
        {
            return new RegisterDetailDao().Update(objRD);
        }
    }
}
