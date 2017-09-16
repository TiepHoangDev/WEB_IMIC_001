using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class IntroduceBcl
    {
        public List<IntroducePageObject> ExecOfGetIntroducePage()
        {
            return new IntroducePageDao().getElements();
        }

        public List<IntroduceBannerObject> ExecOfGetIntroduceBanner()
        {
            return new IntroduceBannerDao().getAllElements();
        }

        public List<IntroduceMissionObject> ExecOfGetIntroduceMission()
        {
            return new IntroduceMissionDao().getAllElements();
        }

        public List<IntroducePartnerObject> ExecOfGetIntroducePartner()
        {
            return new IntroducePartnerDao().getAllElements();
        }

        public List<IntroduceServiceObject> ExecOfGetIntroduceService()
        {
            return new IntroduceServiceDao().getAllElements();
        }

        public List<ExperiencerObject> ExecOfGetAllExperiencer()
        {
            return new ExperiencerDao().getAllElements();
        }

        public IntroduceBannerObject ExecOfGetIntroduceBannerById(Guid Id)
        {
            return new IntroduceBannerDao().getElementsById(Id);
        }

        public bool BannerInsert(IntroduceBannerObject obj)
        {
            return new IntroduceBannerDao().BannerInsert(obj);
        }

        public bool BannerUpdate(IntroduceBannerObject obj)
        {
            return new IntroduceBannerDao().BannerUpdate(obj);
        }

        public bool BannerDelete(Guid bannerId)
        {
            return new IntroduceBannerDao().BannerDelete(bannerId);
        }

        public bool MissionEdit(IntroduceMissionObject objM)
        {
            return new IntroduceMissionDao().MissionInsert(objM);
        }

        public bool ServiceUpdate(IntroduceServiceObject objS)
        {
            return new IntroduceServiceDao().ServiceUpdate(objS);
        }
        public bool PageUpdate(IntroducePageObject objS)
        {
            return new IntroducePageDao().PageUpdate(objS);
        }

        public List<IntroduceEduProgramObject> ExecOfGetIntroduceEduProgram()
        {
            return new IntroduceEduProgramDao().getAllElements();
        }

        public bool EduProgramUpdate(IntroduceEduProgramObject obj)
        {
            return new IntroduceEduProgramDao().EduProgramUpdate(obj);
        }
    }
}
