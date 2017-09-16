
using WCF.DataAccessLayer.Daos;
using WCF.BusinessObjectsLayer.EntityObjects;
using System;
using System.Collections.Generic;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecExperienceBbl
    {
        
public List<RecExperienceObject> GetAll()
{
    return new RecExperienceDao().GetAll();
}


public RecExperienceObject GetByRecExperienceId(byte RecExperienceId)
{
    return new RecExperienceDao().GetByRecExperienceId(RecExperienceId);
}

        
public bool Insert(RecExperienceObject ob)
{
    return new RecExperienceDao().Insert(ob);
}

        
public bool Delete(byte RecExperienceId)
{
    return new RecExperienceDao().Delete(RecExperienceId);
}

        
public bool Update(RecExperienceObject ob)
{
    return new RecExperienceDao().Update(ob);
}

    }
}
