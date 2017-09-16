using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class CourseDao : BaseModel<CourseObject>
    {
        /*
         * Nghiệp vụ về khoá học, đào tạo
         * NgocNB - 11102016
         */

        //private static WebIMicEntities m_objDb;

        /*
         * Insert khoá học
         * NgocNB - 11102016
        */
        public override List<CourseObject> getAllElements()
        {
            List<CourseObject> lisCourse = new List<CourseObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_Course_GetAll();
                foreach (var item in lisTemp)
                {
                    CourseObject objCourse = new CourseObject();

                    objCourse.CourseId = item.CourseId;
                    objCourse.ApprovedBy = item.ApprovedBy;
                    objCourse.ContentEvaluting = item.ContentEvaluting;
                    objCourse.ContentIntroduce = item.ContentIntroduce;
                    objCourse.ContentLearnByVideo = item.ContentLearnByVideo;
                    objCourse.ContentPreferentialPolicy = item.ContentPreferentialPolicy;
                    objCourse.ContentTemplateProject = item.ContentTemplateProject;
                    objCourse.CourseCodeNumber = item.CourseCodeNumber;
                    objCourse.CourseImage = item.CourseImage;
                    objCourse.CourseName = item.CourseName;
                    objCourse.CourseSummary = item.CourseSummary;
                    objCourse.IsApproved = item.IsApproved;
                    objCourse.IsDeleted = item.IsDeleted;
                    objCourse.IsOnline = item.IsOnline;
                    objCourse.Price = item.Price;
                    objCourse.ModifiedBy = item.ModifiedBy;
                    objCourse.Rating = item.Rating;
                    objCourse.SumOfRating = item.SumOfRating;
                    objCourse.TotalOfRating = item.TotalOfRating;
                    objCourse.TotalOfViews = item.TotalOfViews;
                    objCourse.TrainingCategoryId = item.TrainingCategoryId;
                    objCourse.ModifiedTime = item.ModifiedTime;
                    objCourse.ContentIntroduceVideo = item.ContentIntroduceVideo;
                    objCourse.TitleIntroduceVideo = item.TitleIntroduceVideo;
                    objCourse.RankVip = item.RankVip;

                    lisCourse.Add(objCourse);
                }
               
            }
            return lisCourse;
        }

        public bool InsertCourse(CourseObject objCourse)
        {

            using (var dbContext = new WebIMicEntities())
            {
                objCourse.CourseId = Guid.NewGuid();

                // Insert tbl_Course
                dbContext.WEB_IMIC_SP_Course_Update(objCourse.CourseId, objCourse.TrainingCategoryId,
                    objCourse.CourseName,
                    objCourse.CourseImage, objCourse.IsOnline, null, null, null, objCourse.Price, null,
                    objCourse.CourseSummary, objCourse.ContentIntroduce, objCourse.ContentLearnByVideo,
                    objCourse.ContentPreferentialPolicy, objCourse.ContentEvaluting, objCourse.ContentTemplateProject,
                    objCourse.TitleIntroduceVideo, objCourse.ContentIntroduceVideo, null,
                    DateTime.Now, true, null, false, false, objCourse.RankVip);

                // Insert tbl_BoxBelowDetail
                if (objCourse.ListBoxBelowDetail != null)
                {
                    for (int i = 0; i < objCourse.ListBoxBelowDetail.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_BoxBelowDetail_Update(Guid.NewGuid(), objCourse.CourseId,
                        objCourse.ListBoxBelowDetail[i].BoxBelowId, (byte)i, false);
                    }
                }
                

                // Insert tbl_DemoProjectDetail
                if (objCourse.ListCourseDemoProject != null)
                {
                    for (int i = 0; i < objCourse.ListCourseDemoProject.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_DemoProjectDetail_Update(Guid.NewGuid(), objCourse.CourseId,
                            objCourse.ListCourseDemoProject[i].DemoProjectId, (byte)i, false);
                    }
                }
                

                // Insert tbl_CourseTechnologyDetail
                if (objCourse.ListCourseTechnologyDetail != null)
                {
                    for (int i = 0; i < objCourse.ListCourseTechnologyDetail.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_CourseTechnologyDetail_update(Guid.NewGuid(), objCourse.CourseId,
                            objCourse.ListCourseTechnologyDetail[i].CourseTechnologyId, (byte)i, false);
                    }
                }
                

                // Insert tbl_CourseTeacher
                if (objCourse.ListCourseTeacher != null)
                {
                    for (int i = 0; i < objCourse.ListCourseTeacher.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_CourseTeacher_update(Guid.NewGuid(), objCourse.CourseId,
                            objCourse.ListCourseTeacher[i].ExperiencerId, (byte)i, false);
                    }
                }
                
            }


            return true;
        }
        public bool UpdateCourse(CourseObject objCourse)
        {

            using (var dbContext = new WebIMicEntities())
            {
                
                // Update tbl_Course
                dbContext.WEB_IMIC_SP_Course_Update(objCourse.CourseId, objCourse.TrainingCategoryId,
                    objCourse.CourseName,
                    objCourse.CourseImage, objCourse.IsOnline, 5, 10, 50, objCourse.Price, 100,
                    objCourse.CourseSummary, objCourse.ContentIntroduce, objCourse.ContentLearnByVideo,
                    objCourse.ContentPreferentialPolicy, objCourse.ContentEvaluting, objCourse.ContentTemplateProject,
                    objCourse.TitleIntroduceVideo, objCourse.ContentIntroduceVideo, objCourse.ModifiedBy,
                    DateTime.Now, true, objCourse.ApprovedBy, false, true, objCourse.RankVip);
                dbContext.WEB_IMIC_SP_BoxBelowDetail_DeleteByCourseId(objCourse.CourseId);
                // Insert tbl_BoxBelowDetail
                if (objCourse.ListBoxBelowDetail != null)
                {
                    for (int i = 0; i < objCourse.ListBoxBelowDetail.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_BoxBelowDetail_Update(Guid.NewGuid(), objCourse.CourseId,
                        objCourse.ListBoxBelowDetail[i].BoxBelowId, (byte)i, false);
                    }
                }

                dbContext.WEB_IMIC_SP_DemoProjectDetail_DeleteByCourseId(objCourse.CourseId);
                // Insert tbl_DemoProjectDetail
                if (objCourse.ListCourseDemoProject != null)
                {
                    for (int i = 0; i < objCourse.ListCourseDemoProject.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_DemoProjectDetail_Update(Guid.NewGuid(), objCourse.CourseId,
                            objCourse.ListCourseDemoProject[i].DemoProjectId, (byte)i, false);
                    }
                }

                dbContext.WEB_IMIC_SP_CourseTechnologyDetail_DeleteByCourseId(objCourse.CourseId);
                // Insert tbl_CourseTechnologyDetail
                if (objCourse.ListCourseTechnologyDetail != null)
                {
                    for (int i = 0; i < objCourse.ListCourseTechnologyDetail.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_CourseTechnologyDetail_update(Guid.NewGuid(), objCourse.CourseId,
                            objCourse.ListCourseTechnologyDetail[i].CourseTechnologyId, (byte)i, false);
                    }
                }

                dbContext.WEB_IMIC_SP_CourseTeacher_DeleteByCourseId(objCourse.CourseId);
                // Insert tbl_CourseTeacher
                if (objCourse.ListCourseTeacher != null)
                {
                    for (int i = 0; i < objCourse.ListCourseTeacher.Count; i++)
                    {
                        dbContext.WEB_IMIC_SP_CourseTeacher_update(Guid.NewGuid(), objCourse.CourseId,
                            objCourse.ListCourseTeacher[i].ExperiencerId, (byte)i, false);
                    }
                }

            }

            return true;
        }
        public bool DeleteCourse(Guid courseId)
        {

            using (var dbContext = new WebIMicEntities())
            {
                // Chuyển giá trị isdeleted = true
                dbContext.WEB_IMIC_SP_Course_updateIsDeleted(courseId, true);
            }


            return true;
        }
        public CourseObject getById(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            var lisTemp = db.WEB_IMIC_SP_Course_GetByID(id).ToList();
            foreach (var item in lisTemp)
            {
                CourseObject objCourse = new CourseObject();
                objCourse.CourseId = item.CourseId;
                objCourse.ApprovedBy = item.ApprovedBy;
                objCourse.ContentEvaluting = item.ContentEvaluting;
                objCourse.ContentIntroduce = item.ContentIntroduce;
                objCourse.ContentLearnByVideo = item.ContentLearnByVideo;
                objCourse.ContentPreferentialPolicy = item.ContentPreferentialPolicy;
                objCourse.ContentTemplateProject = item.ContentTemplateProject;
                objCourse.TitleIntroduceVideo = item.TitleIntroduceVideo;
                objCourse.ContentIntroduceVideo = item.ContentIntroduceVideo;
                objCourse.CourseCodeNumber = item.CourseCodeNumber;
                objCourse.CourseImage = item.CourseImage;
                objCourse.CourseName = item.CourseName;
                objCourse.CourseSummary = item.CourseSummary;
                objCourse.IsApproved = item.IsApproved;
                objCourse.IsDeleted = item.IsDeleted;
                objCourse.IsOnline = item.IsOnline;
                objCourse.Price = item.Price;
                objCourse.ModifiedBy = item.ModifiedBy;
                objCourse.Rating = item.Rating;
                objCourse.SumOfRating = item.SumOfRating;
                objCourse.TotalOfRating = item.TotalOfRating;
                objCourse.TotalOfViews = item.TotalOfViews;
                objCourse.TrainingCategoryId = item.TrainingCategoryId;
                objCourse.ModifiedTime = item.ModifiedTime;
                objCourse.RankVip = item.RankVip;
                return objCourse;
            }
            return null;
        }
        public List<CourseObject> GetCourseObjectByCourseId(Guid Id)
        {
            List<CourseObject> lisCourse = new List<CourseObject>();
            using (var dbContext = new WebIMicEntities())
            {
                
                var lisTemp = dbContext.WEB_IMIC_SP_Course_GetByID(Id);
                foreach (var item in lisTemp)
                {
                    CourseObject objCourse = new CourseObject();

                    objCourse.CourseId = item.CourseId;
                    objCourse.ApprovedBy = item.ApprovedBy;
                    objCourse.ContentEvaluting = item.ContentEvaluting;
                    objCourse.ContentIntroduce = item.ContentIntroduce;
                    objCourse.ContentLearnByVideo = item.ContentLearnByVideo;
                    objCourse.ContentPreferentialPolicy = item.ContentPreferentialPolicy;
                    objCourse.ContentTemplateProject = item.ContentTemplateProject;
                    objCourse.TitleIntroduceVideo = item.TitleIntroduceVideo;
                    objCourse.ContentIntroduceVideo = item.ContentIntroduceVideo;
                    objCourse.CourseCodeNumber = item.CourseCodeNumber;
                    objCourse.CourseImage = item.CourseImage;
                    objCourse.CourseName = item.CourseName;
                    objCourse.CourseSummary = item.CourseSummary;
                    objCourse.IsApproved = item.IsApproved;
                    objCourse.IsDeleted = item.IsDeleted;
                    objCourse.IsOnline = item.IsOnline;
                    objCourse.Price = item.Price;
                    objCourse.ModifiedBy = item.ModifiedBy;
                    objCourse.Rating = item.Rating;
                    objCourse.SumOfRating = item.SumOfRating;
                    objCourse.TotalOfRating = item.TotalOfRating;
                    objCourse.TotalOfViews = item.TotalOfViews;
                    objCourse.TrainingCategoryId = item.TrainingCategoryId;
                    objCourse.ModifiedTime = item.ModifiedTime;
                    objCourse.RankVip = item.RankVip;

                    lisCourse.Add(objCourse);
                }

            }
            return lisCourse;
        }

        public List<CourseObject> GetCourseObjectByCodeNumber(int codeNumber)
        {
            List<CourseObject> lisCourse = new List<CourseObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_Course_GetByCodeNumber(codeNumber);
                foreach (var item in lisTemp)
                {
                    CourseObject objCourse = new CourseObject();

                    objCourse.CourseId = item.CourseId;
                    objCourse.ApprovedBy = item.ApprovedBy;
                    objCourse.ContentEvaluting = item.ContentEvaluting;
                    objCourse.ContentIntroduce = item.ContentIntroduce;
                    objCourse.ContentLearnByVideo = item.ContentLearnByVideo;
                    objCourse.ContentPreferentialPolicy = item.ContentPreferentialPolicy;
                    objCourse.ContentTemplateProject = item.ContentTemplateProject;
                    objCourse.CourseCodeNumber = item.CourseCodeNumber;
                    objCourse.CourseImage = item.CourseImage;
                    objCourse.CourseName = item.CourseName;
                    objCourse.CourseSummary = item.CourseSummary;
                    objCourse.IsApproved = item.IsApproved;
                    objCourse.IsDeleted = item.IsDeleted;
                    objCourse.IsOnline = item.IsOnline;
                    objCourse.Price = item.Price;
                    objCourse.ModifiedBy = item.ModifiedBy;
                    objCourse.Rating = item.Rating;
                    objCourse.SumOfRating = item.SumOfRating;
                    objCourse.TotalOfRating = item.TotalOfRating;
                    objCourse.TotalOfViews = item.TotalOfViews;
                    objCourse.TrainingCategoryId = item.TrainingCategoryId;
                    objCourse.ModifiedTime = item.ModifiedTime;
                    objCourse.TitleIntroduceVideo = item.TitleIntroduceVideo;
                    objCourse.ContentIntroduceVideo = item.ContentIntroduceVideo;
                    objCourse.RankVip = item.RankVip;

                    lisCourse.Add(objCourse);
                }

            }
            return lisCourse;
        }

        public List<CourseObject> GetAllCourseByTrainingCategoryId(Guid trainingCategoryId)
        {
            List<CourseObject> lisCourse = new List<CourseObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_Course_getAllByTrainingCategoryId(trainingCategoryId);
                foreach (var item in lisTemp)
                {
                    
                        CourseObject objCourse = new CourseObject();

                        objCourse.CourseId = item.CourseId;
                        objCourse.ApprovedBy = item.ApprovedBy;
                        objCourse.ContentEvaluting = item.ContentEvaluting;
                        objCourse.ContentIntroduce = item.ContentIntroduce;
                        objCourse.ContentLearnByVideo = item.ContentLearnByVideo;
                        objCourse.ContentPreferentialPolicy = item.ContentPreferentialPolicy;
                        objCourse.ContentTemplateProject = item.ContentTemplateProject;
                        objCourse.TitleIntroduceVideo = item.TitleIntroduceVideo;
                        objCourse.CourseCodeNumber = item.CourseCodeNumber;
                        objCourse.CourseImage = item.CourseImage;
                        objCourse.CourseName = item.CourseName;
                        objCourse.CourseSummary = item.CourseSummary;
                        objCourse.IsApproved = item.IsApproved;
                        objCourse.IsDeleted = item.IsDeleted;
                        objCourse.IsOnline = item.IsOnline;
                        objCourse.Price = item.Price;
                        objCourse.ModifiedBy = item.ModifiedBy;
                        objCourse.Rating = item.Rating;
                        objCourse.SumOfRating = item.SumOfRating;
                        objCourse.TotalOfRating = item.TotalOfRating;
                        objCourse.TotalOfViews = item.TotalOfViews;
                        objCourse.TrainingCategoryId = item.TrainingCategoryId;
                        objCourse.ModifiedTime = item.ModifiedTime;
                        objCourse.ContentIntroduceVideo = item.ContentIntroduceVideo;
                        objCourse.RankVip = item.RankVip;

                        lisCourse.Add(objCourse);
                    
                }

            }
            return lisCourse;
        }
        public List<CourseObject> GetAllCourseByTCCodeNumber(int tcCodeNumber)
        {
            List<CourseObject> lisCourse = new List<CourseObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_Course_GetByTCCodeNumber(tcCodeNumber);
                foreach (var item in lisTemp)
                {

                    CourseObject objCourse = new CourseObject();

                    objCourse.CourseId = item.CourseId;
                    objCourse.ApprovedBy = item.ApprovedBy;
                    objCourse.ContentEvaluting = item.ContentEvaluting;
                    objCourse.ContentIntroduce = item.ContentIntroduce;
                    objCourse.ContentLearnByVideo = item.ContentLearnByVideo;
                    objCourse.ContentPreferentialPolicy = item.ContentPreferentialPolicy;
                    objCourse.ContentTemplateProject = item.ContentTemplateProject;
                    objCourse.CourseCodeNumber = item.CourseCodeNumber;
                    objCourse.CourseImage = item.CourseImage;
                    objCourse.CourseName = item.CourseName;
                    objCourse.CourseSummary = item.CourseSummary;
                    objCourse.IsApproved = item.IsApproved;
                    objCourse.IsDeleted = item.IsDeleted;
                    objCourse.IsOnline = item.IsOnline;
                    objCourse.Price = item.Price;
                    objCourse.ModifiedBy = item.ModifiedBy;
                    objCourse.Rating = item.Rating;
                    objCourse.SumOfRating = item.SumOfRating;
                    objCourse.TotalOfRating = item.TotalOfRating;
                    objCourse.TotalOfViews = item.TotalOfViews;
                    objCourse.TrainingCategoryId = item.TrainingCategoryId;
                    objCourse.ModifiedTime = item.ModifiedTime;
                    objCourse.TitleIntroduceVideo = item.TitleIntroduceVideo;
                    objCourse.ContentIntroduceVideo = item.ContentIntroduceVideo;
                    objCourse.RankVip = item.RankVip;

                    lisCourse.Add(objCourse);
                }

            }
            return lisCourse;
        }
    }
}
