
using WCF.DataAccessLayer.Daos;
using WCF.BusinessObjectsLayer.EntityObjects;
using System;
using System.Collections.Generic;
namespace WCF.BusinessControlLayer.Bcls
{
    public class RecruitmentCompanyBbl
    {
        
public List<RecruitmentCompanyObject> GetAll()
{
    return new RecruitmentCompanyDao().GetAll();
}

        
public RecruitmentCompanyObject GetByCompanyId(System.Guid CompanyId)
{
    return new RecruitmentCompanyDao().GetByCompanyId(CompanyId);
}

        
public bool Insert(RecruitmentCompanyObject ob)
{
    return new RecruitmentCompanyDao().Insert(ob);
}

        
public bool Delete(System.Guid CompanyId)
{
    return new RecruitmentCompanyDao().Delete(CompanyId);
}

        
public bool Update(RecruitmentCompanyObject ob)
{
    return new RecruitmentCompanyDao().Update(ob);
}

    }
}
