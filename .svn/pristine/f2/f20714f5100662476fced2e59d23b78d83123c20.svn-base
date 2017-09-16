
using WCF.DataAccessLayer.Daos;
using WCF.BusinessObjectsLayer.EntityObjects;
using System;
using System.Collections.Generic;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecCareerBbl
    {
        
public List<RecCareerObject> GetAll()
{
    return new RecCareerDao().GetAll();
}

        
public RecCareerObject GetByRecCareerId(System.Int32 RecCareerId)
{
    return new RecCareerDao().GetByRecCareerId(RecCareerId);
}

        
public bool Insert(RecCareerObject ob)
{
    return new RecCareerDao().Insert(ob);
}

        
public bool Delete(System.Int32 RecCareerId)
{
    return new RecCareerDao().Delete(RecCareerId);
}

        
public bool Update(RecCareerObject ob)
{
    return new RecCareerDao().Update(ob);
}

    }
}
