using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;
namespace WCF.BusinessControlLayer.Bcls
{
    public class LessonBCL_Alt
    {
        public List<LessonDetailObject> SearchByTitle(string query, int start, int lenght)
        {
            return new LessonDao_Alt().SearchByTitle(query,start,lenght) ;
        }
        public List<LessonDetailObject> SearchByTag(string query, int start, int lenght)
        {
            return new LessonDao_Alt().SearchByTag(query, start, lenght);
        }
        public List<LessonCategoryObject> getAllCategory()
        {
            return new LessonCategoryDAO().getElements();
        }
        public List<LessonDetailObject> getPopular()
        {
            return new LessonDao_Alt().getPopular();
        }
        public List<LessonObject> getLessonByCat(Guid catid)
        {
            return new LessonDao_Alt().getLessonByCat(catid);
        }

        public List<LessonObject> getElementsByCategory(Guid catid)
        {
            return new LessonDao_Alt().getElementsByCategory(catid);
        }
        public List<LessonObject> getAllLesson_Paging(int start, int length)
        {

            return new LessonDao_Alt().getAllLesson_Paging(start,length);
        }
        public List<LessonDetailObject> getLessonDetailByLesson(Guid lessonid)
        {
            return new LessonDao_Alt().getLessonDetailByLesson(lessonid);
        }
        public List<LessonDetailObject> getLessonDetailByLesson_PAGING(Guid lessonid, int start, int length)
        {
            return new LessonDao_Alt().getLessonDetailByLesson_PAGING(lessonid, start, length);
        }
        public LessonDetailObject getByCode(long code)
        {
            return new LessonDao_Alt().getByCode(code);
        }
        public int[] getCount()
        {
            return new LessonDao_Alt().getCount();
        }

        public int getCountByTag(string tag)
        {
            return new LessonDao_Alt().GetCountTag(tag);
        }
        public int getCountByTitle(string title)
        {
            return new LessonDao_Alt().getcountTitle(title);
        }
    }
}
