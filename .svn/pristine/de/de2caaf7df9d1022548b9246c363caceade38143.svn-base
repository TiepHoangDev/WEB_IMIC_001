using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class OthersBcl
    {
        public List<FacebookUserLikedObject> GetAllFacebookUserLiked()
        {
            return new FacebookUserLikedDao().GetAllFacebookUserLiked();
        }

        public bool InsertFacebookUserLiked(FacebookUserLikedObject obj)
        {
            return new FacebookUserLikedDao().InsertFacebookUserLiked(obj);
        }

        public bool UpdateFacebookUserLiked(FacebookUserLikedObject obj)
        {
            return new FacebookUserLikedDao().UpdateFacebookUserLiked(obj);
        }

        public FacebookUserLikedObject GetFacebookUserLikedById(Guid facebookUserLikedId)
        {
            return new FacebookUserLikedDao().getById(facebookUserLikedId);
        }

        public bool DeleteFacebookUserLiked(Guid fbId)
        {
            return new FacebookUserLikedDao().DeleteFacebookUserLiked(fbId);
        }
    }
}
