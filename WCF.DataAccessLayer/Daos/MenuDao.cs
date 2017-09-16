using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class MenuDao : BaseModel<MenuCategoryObject>
    {
        public List<MenuCategoryObject> GetAllMenuCatByWelcomeId(Guid WPId)
        {
            List<MenuCategoryObject> lisMC = new List<MenuCategoryObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisTemp = dbContext.WEB_IMIC_SP_MenuCategory_GetAllByWelcomeId(WPId).ToList();
                foreach (var item in lisTemp)
                {
                    MenuCategoryObject objMc = new MenuCategoryObject();
                    
                    objMc.MenuId = item.MenuId;
                    objMc.MenuLink = item.MenuLink;
                    objMc.IsDeleted = item.IsDeleted;
                    objMc.MenuText = item.MenuText;
                    lisMC.Add(objMc);
                }
                
            }
            return lisMC;
        }
    }
}
