
using System;
using System.Collections.Generic;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RecCareerDao
    {
        
public List<RecCareerObject> GetAll()
{
    var list = new WebIMicEntities().WEB_IMIC_SP_RecCareer_GetAll();
    List<RecCareerObject> lst = new List<RecCareerObject>();
    foreach (var item in list)
    {
        var obj = new RecCareerObject();
        
obj.RecCareerId = item.RecCareerId  ;
obj.RecCareerName = item.RecCareerName  ;
        lst.Add(obj);
    }
    return lst;
}

        
public RecCareerObject GetByRecCareerId(System.Int32 RecCareerId)
{
    var list =  new WebIMicEntities().WEB_IMIC_SP_RecCareer_GetByRecCareerId(RecCareerId);
    foreach (var item in list)
    {
        var obj = new RecCareerObject();
        
obj.RecCareerId = item.RecCareerId  ;
obj.RecCareerName = item.RecCareerName  ;
        return obj;
    }
    return null;
}

        
public bool Insert(RecCareerObject ob)
{
    return new WebIMicEntities().WEB_IMIC_SP_RecCareer_Insert( ob.RecCareerName )>0;
}

        
public bool Delete( System.Int32 RecCareerId)
{
    return new WebIMicEntities().WEB_IMIC_SP_RecCareer_Delete( RecCareerId)>0;
}

        
public bool Update(RecCareerObject ob)
{
    return new WebIMicEntities().WEB_IMIC_SP_RecCareer_Update( ob.RecCareerId , ob.RecCareerName )>0;
}

    }
}
