using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class MenuCategoryObject
    {
        public byte MenuId { get; set; }
        public string MenuText { get; set; }
        public string MenuLink { get; set; }
        public bool IsDeleted { get; set; }
    
        public List<MenuCategoryDetailObject> listDetailMenuCat { get; set; }
    }
}
