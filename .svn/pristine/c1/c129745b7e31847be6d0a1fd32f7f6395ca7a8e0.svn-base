using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class TrainingPageDao
    {
        /*
         * Xử lý trường thông tin trang đào tạo
         * NgocNB - 05102016
         */

        

        /*
         * Lấy trường thông tin chung của trang đào tạo
         * NgocNB - 05102016
         */
        public TrainingPageObject GetTrainingPage()
        {
            TrainingPageObject objTP;
            using (var dbcontext = new WebIMicEntities())
            {
                var objGet = dbcontext.WEB_IMIC_SP_TrainingPage_GetAll().SingleOrDefault();
                objTP = new TrainingPageObject
                {
                    TrainingPageId = objGet.TrainingPageId,
                    CalendarDescription = objGet.CalendarDescription,
                    CalendarLinkTo = objGet.CalendarLinkTo,
                    CalendarTitle = objGet.CalendarTitle,
                    LearningTimeTitle = objGet.LearningTimeTitle,
                    ModifiedBy = objGet.ModifiedBy,
                    ModifiedTime = objGet.ModifiedTime + "",
                    SessionName1 = objGet.SessionName1,
                    SessionName2 = objGet.SessionName2,
                    SessionName3 = objGet.SessionName3,
                    SessionName4 = objGet.SessionName4,
                    SessionTime1 = objGet.SessionTime1,
                    SessionTime2 = objGet.SessionTime2,
                    SessionTime3 = objGet.SessionTime3,
                    SessionTime4 = objGet.SessionTime4,
                    TeacherDescription = objGet.TeacherDescription,
                    TeacherTitle = objGet.TeacherTitle,
                    TeacherLinkTo = objGet.TeacherLinkTo
                };
            }


            return objTP;
        }

        public bool TrainingPageUpdate(TrainingPageObject objTP)
        {
            using (var dbContext = new WebIMicEntities())
            {
                dbContext.WEB_IMIC_SP_TrainingPage_update(objTP.TrainingPageId, objTP.LearningTimeTitle,
                    objTP.SessionName1, objTP.SessionTime1, objTP.SessionName2, objTP.SessionTime2, objTP.SessionName3,
                    objTP.SessionTime3, objTP.SessionName4, objTP.SessionTime4, objTP.CalendarTitle,
                    objTP.CalendarDescription, objTP.CalendarLinkTo, objTP.TeacherTitle, objTP.TeacherDescription,
                    objTP.TeacherLinkTo, objTP.ModifiedBy, DateTime.Now, false);
            }
            return true;
        }
    }
}
