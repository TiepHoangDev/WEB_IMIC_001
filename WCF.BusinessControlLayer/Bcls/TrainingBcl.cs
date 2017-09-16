using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class TrainingBcl
    {
        /*
         * Nghiệp vụ trang đào tạo
         * NgocNB - 05102016
         */

        public List<TrainingBannerObject> GetBannersToShow()
        {
            return TrainingBannerDao.GetBannersToShow();
        }

        public TrainingPageObject GetTrainingPage()
        {
            return new TrainingPageDao().GetTrainingPage();
        }

        public bool TrainingPageUpdate(TrainingPageObject objTP)
        {
            return new TrainingPageDao().TrainingPageUpdate(objTP);
        }

        public List<TrainingCategoryObject> GetCategoriesAll()
        {
            return new TrainingCategoryDao().getAllElements();
        }

        public List<BoxBelowObject> GetBoxBellowAll()
        {
            return new BoxBellowDao().getAllElements();
        }

        public List<DemoProjectObject> GetDemoProjectAll()
        {
            return new DemoProjectDao().getAllElements();
        }

        public List<ExperiencerObject> GetExperiencerAll()
        {
            return new ExperiencerDao().getAllElements();
        }

        public CourseObject GetById(Guid id)
        {
            return new CourseDao().getById(id);
        }
        public bool InsertCourse(CourseObject objCourse)
        {
            return new CourseDao().InsertCourse(objCourse);
        }

        public bool UpdateCourse(CourseObject objCourse)
        {
            return new CourseDao().UpdateCourse(objCourse);
        }

        public bool DeleteCourse(Guid courseId)
        {
            return new CourseDao().DeleteCourse(courseId);
        }

        public List<CourseTechnologyObject> GetTechnologyAll()
        {
            return new CourseTechnologyDao().getAllElements();
        }

        public List<CourseObject> ExecOfGetCourseObjectByCourseId(Guid courseId)
        {
            return new CourseDao().GetCourseObjectByCourseId(courseId);
        }

        public List<CourseObject> ExecOfGetCourseObjectByCodeNumber(int codeNumber)
        {
            return new CourseDao().GetCourseObjectByCodeNumber(codeNumber);
        }

        public List<CourseObject> ExecOfGetAllCourse()
        {
            return new CourseDao().getAllElements();
        }

        public List<CourseTechnologyObject> ExecOfGetAllTechnologyByCourseId(Guid courseId)
        {
            return new CourseTechnologyDao().GetAllTechnologyByCourseId(courseId);
        }

        public List<DemoProjectObject> ExecOfGetAllDemoProjectByCourseId(Guid courseId)
        {
            return new DemoProjectDao().GetAllDemoProjectByCourseId(courseId);
        }

        public List<BoxBelowObject> ExecOfGetAllBoxBelowByCourseId(Guid courseId)
        {
            return new BoxBellowDao().GetAllBoxBelowByCourseId(courseId);
        }

        public List<CourseObject> ExecOfGetAllCourseByTrainingCategoryId(Guid trainingCategoryId)
        {
            return new CourseDao().GetAllCourseByTrainingCategoryId(trainingCategoryId);
        }
        public List<CourseObject> ExecOfGetAllCourseByTCCodeNumber(int tcCodeNumber)
        {
            return new CourseDao().GetAllCourseByTCCodeNumber(tcCodeNumber);
        }

        public List<ExperiencerObject> ExecOfGetExperiencerByCourseId(Guid courseId)
        {
            return new ExperiencerDao().GetExperiencerByCourseId(courseId);
        }
        public BoxBelowObject GetBelowObjectById(Guid Id)
        {
            return new BoxBellowDao().GetBoxBelowByBBid(Id);
        }
        public bool BoxBelowInsert(BoxBelowObject objBB)
        {
            return new BoxBellowDao().Insert(objBB);
        }

        public bool BoxBelowUpdate(BoxBelowObject obj)
        {
            return new BoxBellowDao().Update(obj);
        }
        public bool BoxBelowDelete(Guid id)
        {
            return new BoxBellowDao().Delete(id);
        }

        public bool DemoProjectInsert(DemoProjectObject objDP)
        {
            return new DemoProjectDao().Insert(objDP);
        }

        public bool CourseTechInsert(CourseTechnologyObject objCT)
        {
            return new CourseTechnologyDao().Insert(objCT);
        }
    }
}
