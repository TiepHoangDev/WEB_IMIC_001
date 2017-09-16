using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class WelcomePageBcl : BaseController<WelcomePageObject>

    {
        public static List<WelcomePageObject> ExecOfGetElements()
        {
            return new WelcomePageDAO().getAllElements();
        }

        public static List<MenuCategoryObject> ExecOfGetMenuCategoryByWelcomeId(Guid WelcomeId)
        {
            return new MenuDao().GetAllMenuCatByWelcomeId(WelcomeId);
        }
    }
}
