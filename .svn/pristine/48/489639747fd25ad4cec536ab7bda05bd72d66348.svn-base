
using System;
using System.Collections.Generic;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class RecruitmentCompanyDao
    {

        public List<RecruitmentCompanyObject> GetAll()
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecruitmentCompany_GetAll1();
            List<RecruitmentCompanyObject> lst = new List<RecruitmentCompanyObject>();
            foreach (var item in list)
            {
                var obj = new RecruitmentCompanyObject();

                obj.Address = item.Address;
                obj.CompanyCode = item.CompanyCode;
                obj.CompanyFullName = item.CompanyFullName;
                obj.CompanyId = item.CompanyId;
                obj.CompanyImage = item.CompanyImage;
                obj.CompanyImageAlt = item.CompanyImageAlt;
                obj.CompanyLink = item.CompanyLink;
                obj.CompanyLogo = item.CompanyLogo;
                obj.CompanyName = item.CompanyName;
                obj.Hotline = item.Hotline;
                obj.IsApproved = item.IsApproved == true;
                obj.Rank = item.Rank.HasValue ? (byte)9 : item.Rank.Value;
                obj.TotalOfNewsletter = item.TotalOfNewsletter;
                lst.Add(obj);
            }
            return lst;
        }


        public RecruitmentCompanyObject GetByCompanyId(System.Guid CompanyId)
        {
            var list = new WebIMicEntities().WEB_IMIC_SP_RecruitmentCompany_GetByCompanyId(CompanyId);
            foreach (var item in list)
            {
                var obj = new RecruitmentCompanyObject();

                obj.Address = item.Address;
                obj.CompanyCode = item.CompanyCode;
                obj.CompanyFullName = item.CompanyFullName;
                obj.CompanyId = item.CompanyId;
                obj.CompanyImage = item.CompanyImage;
                obj.CompanyImageAlt = item.CompanyImageAlt;
                obj.CompanyLink = item.CompanyLink;
                obj.CompanyLogo = item.CompanyLogo;
                obj.CompanyName = item.CompanyName;
                obj.Hotline = item.Hotline;
                obj.IsApproved = item.IsApproved == true;
                obj.Rank = item.Rank.Value;
                obj.TotalOfNewsletter = item.TotalOfNewsletter;
                return obj;
            }
            return null;
        }


        public bool Insert(RecruitmentCompanyObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecruitmentCompany_Insert1(ob.Address, ob.CompanyCode, ob.CompanyFullName, ob.CompanyId, ob.CompanyImage, ob.CompanyImageAlt, ob.CompanyLink, ob.CompanyLogo, ob.CompanyName, ob.Hotline, ob.IsApproved, ob.Rank, ob.TotalOfNewsletter) > 0;
        }


        public bool Delete(System.Guid CompanyId)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecruitmentCompany_Delete(CompanyId) > 0;
        }


        public bool Update(RecruitmentCompanyObject ob)
        {
            return new WebIMicEntities().WEB_IMIC_SP_RecruitmentCompany_Update1(ob.Address, ob.CompanyCode, ob.CompanyFullName, ob.CompanyId, ob.CompanyImage, ob.CompanyImageAlt, ob.CompanyLink, ob.CompanyLogo, ob.CompanyName, ob.Hotline, ob.IsApproved, ob.Rank, ob.TotalOfNewsletter) > 0;
        }

    }
}
