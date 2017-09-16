
using System;
using System.Collections.Generic;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class OpenClassPageDao
    {

        public OpenClassPageObject GetAll()
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_OpenClassPage_GetAll();
            foreach (var item in list)
            {
                var obj = new OpenClassPageObject();

                obj.LinkButton = item.LinkButton;
                obj.MiddleTilte = item.MiddleTilte;
                obj.SubTilte = item.SubTilte;
                obj.TopImage = item.TopImage;
                obj.TopImageAlt = item.TopImageAlt;
                obj.TopTitle = item.TopTitle;
                return obj;
            }
            return null;
        }


        public bool Insert(OpenClassPageObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_OpenClassPage_Insert(ob.LinkButton, ob.MiddleTilte, ob.SubTilte, ob.TopImage, ob.TopImageAlt, ob.TopTitle) > 0;
        }


        
        public bool Update(OpenClassPageObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_OpenClassPage_Update(ob.LinkButton, ob.MiddleTilte, ob.SubTilte, ob.TopImage, ob.TopImageAlt, ob.TopTitle) > 0;
        }

    }
}
