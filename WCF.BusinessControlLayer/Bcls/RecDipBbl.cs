
using WCF.DataAccessLayer.Daos;
using WCF.BusinessObjectsLayer.EntityObjects;
using System;
using System.Collections.Generic;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecDipBbl
    {
        
public List<RecDipObject> GetAll()
{
    return new RecDipDao().GetAll();
}


public RecDipObject GetByRecDipId(byte RecDipId)
{
    return new RecDipDao().GetByRecDipId(RecDipId);
}

        
public bool Insert(RecDipObject ob)
{
    return new RecDipDao().Insert(ob);
}


public bool Delete(byte RecDipId)
{
    return new RecDipDao().Delete(RecDipId);
}

        
public bool Update(RecDipObject ob)
{
    return new RecDipDao().Update(ob);
}

    }
}
