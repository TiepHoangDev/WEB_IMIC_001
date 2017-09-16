using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;
namespace WCF.DataAccessLayer.Daos
{
    public class RecruitmentNewsLetterDAO
    {
        public List<RecruitmentNewsletterObject> getElements()
        {
            List<RecruitmentNewsletterObject> lstNew = new List<RecruitmentNewsletterObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETALL())
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();
                objNew.ApprovedBy = (Guid)item.ApprovedBy;
                objNew.CompanyId = (Guid)item.CompanyId;
                objNew.objCompany = new RecruitmentCompanyObject()
                {
                    CompanyName = item.CompanyName,
                    CompanyFullName = item.CompanyFullName
                };
                objNew.Content = item.Content;
                objNew.Description = item.Description;
                objNew.ImageAlt = item.ImageAlt;
                objNew.ImageLink = item.ImageLink;
                objNew.ImageServerFlag = (bool)item.ImageServerFlag;
                objNew.isApproved = (bool)item.IsApproved;
                objNew.isDeleted = (bool)item.IsDeleted;
                objNew.ModifiedBy = (Guid)item.ModifiedBy;
                objNew.ModifiedTime = (DateTime)item.ModifiedTime;
                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Rank = (int)item.Rank;
                objNew.Title = item.Title;
                objNew.TotalOfLikes = (int)item.TotalOfLikes;
                objNew.TotalOfShareFacebook = (int)item.TotalOfShareFacebook;
                objNew.TotalOfShareGoogle = (int)item.TotalOfShareGoogle;
                objNew.TotalOfShareIn = (int)item.TotalOfShareIn;
                objNew.TotalOfShareTwitter = (int)item.TotalOfShareTwitter;
                objNew.TotalOfViews = (int)item.TotalOfViews;

                lstNew.Add(objNew);
            }
            return lstNew;
        }
        public List<RecruitmentNewsletterObject> getPopular()
        {
            List<RecruitmentNewsletterObject> lstNew = new List<RecruitmentNewsletterObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETPOPULAR())
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();
                objNew.CompanyId = (Guid)item.CompanyId;
                objNew.ImageAlt = item.ImageAlt;
                objNew.ImageLink = item.ImageLink;
                objNew.ImageServerFlag = (bool)item.ImageServerFlag;
                objNew.ModifiedTime = (DateTime)item.ModifiedTime;
                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Title = item.Title;
                objNew.TotalOfLikes = (int)item.TotalOfLikes;
                objNew.TotalOfViews = (int)item.TotalOfViews;
                lstNew.Add(objNew);
            }
            return lstNew;
        }
        public List<RecruitmentNewsletterObject> getRelated(Guid id)
        {
            List<RecruitmentNewsletterObject> lstNew = new List<RecruitmentNewsletterObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETRELATED(id))
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();
                objNew.CompanyId = (Guid)item.CompanyId;
                objNew.ImageAlt = item.ImageAlt;
                objNew.ImageLink = item.ImageLink;
                objNew.ImageServerFlag = (bool)item.ImageServerFlag;
                objNew.ModifiedTime = (DateTime)item.ModifiedTime;
                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Title = item.Title;
                objNew.TotalOfLikes = (int)item.TotalOfLikes;
                objNew.TotalOfViews = (int)item.TotalOfViews;
                lstNew.Add(objNew);
            }
            return lstNew;
        }
        public List<RecruitmentNewsletterObject> getRelated_Category(Guid id)
        {
            List<RecruitmentNewsletterObject> lstNew = new List<RecruitmentNewsletterObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETRELATED_CATEGORY(id))
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();


                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Title = item.Title;
                objNew.objCompany = new RecruitmentCompanyObject()
                {
                    CompanyName = item.CompanyName
                };
                objNew.TotalOfViews = (int)item.TotalOfViews;
                lstNew.Add(objNew);
            }
            return lstNew;
        }
        public RecruitmentNewsletterObject getByCode(long code)
        {

            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETBYCODE(code))
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();
                objNew.ApprovedBy = (Guid)item.ApprovedBy;
                objNew.CompanyId = (Guid)item.CompanyId;

                objNew.Content = item.Content;
                objNew.Description = item.Description;
                objNew.ImageAlt = item.ImageAlt;
                objNew.ImageLink = item.ImageLink;
                objNew.ImageServerFlag = (bool)item.ImageServerFlag;
                objNew.ContactInfo = item.ContactInfo;
                objNew.EmployerInfo = item.EmployerInfo;
                objNew.isDeleted = (bool)item.IsDeleted;
                objNew.ModifiedBy = (Guid)item.ModifiedBy;
                objNew.ModifiedTime = (DateTime)item.ModifiedTime;
                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Rank = (int)item.Rank;
                objNew.Title = item.Title;
                objNew.TotalOfLikes = (int)item.TotalOfLikes;
                objNew.TotalOfShareFacebook = (int)item.TotalOfShareFacebook;
                objNew.TotalOfShareGoogle = (int)item.TotalOfShareGoogle;
                objNew.TotalOfShareIn = (int)item.TotalOfShareIn;
                objNew.TotalOfShareTwitter = (int)item.TotalOfShareTwitter;
                objNew.TotalOfViews = (int)item.TotalOfViews;
                objNew.objCompany = new RecruitmentCompanyObject()
                {
                    CompanyName = item.CompanyName,
                    CompanyFullName = item.CompanyFullName
                };
                return objNew;
            }
            return null;
        }
        public void deleteElement(Guid id)
        {
            new WebIMicEntities().WEB_IMIC_SP_RecruitmentNewsLetter_DELETE(id);
        }

        public void ApproveNewsLetter(Guid id)
        {
            WebIMicEntities db =new WebIMicEntities();
            db.WEB_IMIC_SP_RecruitNewsLetter_Approve(id);
        }
        public RecruitmentNewsletterObject getByID(Guid id)
        {

            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETBYID(id))
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();
                objNew.ApprovedBy = (Guid)item.ApprovedBy;
                objNew.CompanyId = (Guid)item.CompanyId;

                objNew.Content = item.Content;
                objNew.Description = item.Description;
                objNew.ImageAlt = item.ImageAlt;
                objNew.ImageLink = item.ImageLink;
                objNew.ImageServerFlag = (bool)item.ImageServerFlag;
                objNew.isApproved = (bool)item.IsApproved;
                objNew.isDeleted = (bool)item.IsDeleted;
                objNew.ModifiedBy = (Guid)item.ModifiedBy;
                objNew.ModifiedTime = (DateTime)item.ModifiedTime;
                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Rank = (int)item.Rank;
                objNew.Title = item.Title;
                objNew.TotalOfLikes = (int)item.TotalOfLikes;
                objNew.TotalOfShareFacebook = (int)item.TotalOfShareFacebook;
                objNew.TotalOfShareGoogle = (int)item.TotalOfShareGoogle;
                objNew.TotalOfShareIn = (int)item.TotalOfShareIn;
                objNew.TotalOfShareTwitter = (int)item.TotalOfShareTwitter;
                objNew.TotalOfViews = (int)item.TotalOfViews;
                objNew.ContactInfo = item.ContactInfo;
                objNew.EmployerInfo = item.EmployerInfo;
                return objNew;
            }
            return null;
        }
        public List<RecruitmentNewsletterObject> getForPaging(int? code, string query, int start, int length)
        {
            List<RecruitmentNewsletterObject> lstNew = new List<RecruitmentNewsletterObject>();
            WebIMicEntities db = new WebIMicEntities();
            foreach (var item in db.WEB_IMIC_SP_RecruitmentNewsLetter_GETALL_PAGING(code, query, start, length))
            {
                RecruitmentNewsletterObject objNew = new RecruitmentNewsletterObject();

                objNew.CompanyId = (Guid)item.CompanyId;

                objNew.Description = item.Description;
                objNew.ImageAlt = item.ImageAlt;
                objNew.ImageLink = item.ImageLink;
                objNew.ImageServerFlag = (bool)item.ImageServerFlag;

                objNew.ModifiedBy = (Guid)item.ModifiedBy;
                objNew.ModifiedTime = (DateTime)item.ModifiedTime;
                objNew.NewsletterCode = (long)item.NewsLetterCode;
                objNew.NewsletterId = item.NewsLetterId;
                objNew.Rank = (int)item.Rank;
                objNew.Title = item.Title;
                objNew.TotalOfLikes = (int)item.TotalOfLikes;
                objNew.TotalOfShareFacebook = (int)item.TotalOfShareFacebook;
                objNew.TotalOfShareGoogle = (int)item.TotalOfShareGoogle;
                objNew.TotalOfShareIn = (int)item.TotalOfShareIn;
                objNew.TotalOfShareTwitter = (int)item.TotalOfShareTwitter;
                objNew.TotalOfViews = (int)item.TotalOfViews;
                objNew.objCompany = new RecruitmentCompanyObject()
                {
                    CompanyName = item.CompanyName,
                    CompanyFullName = item.CompanyFullName
                };
                lstNew.Add(objNew);
            }
            return lstNew;
        }
        public void addElement(RecruitmentNewsletterObject objNew)
        {
            new WebIMicEntities().WEB_IMIC_SP_RecruitmentNewsLetter_INSERT(objNew.NewsletterId, objNew.CompanyId, objNew.ImageLink,
                objNew.ImageServerFlag, objNew.ImageAlt, objNew.Title, objNew.Description, objNew.Content, objNew.ContactInfo, objNew.EmployerInfo,
                objNew.TotalOfShareFacebook,
                objNew.TotalOfShareGoogle, objNew.TotalOfShareTwitter, objNew.TotalOfShareIn, objNew.TotalOfLikes,
                objNew.TotalOfViews, (byte)objNew.Rank, objNew.ModifiedBy, objNew.ModifiedTime, objNew.isApproved, objNew.ApprovedBy, objNew.isDeleted);
        }
        public void updateElement(RecruitmentNewsletterObject objNew)
        {
            new WebIMicEntities().WEB_IMIC_SP_RecruitmentNewsLetter_UPDATE(objNew.NewsletterId, objNew.CompanyId, objNew.ImageLink,
                objNew.ImageServerFlag, objNew.ImageAlt, objNew.Title, objNew.Description, objNew.Content, objNew.ContactInfo, objNew.EmployerInfo,
                objNew.TotalOfShareFacebook,
                objNew.TotalOfShareGoogle, objNew.TotalOfShareTwitter, objNew.TotalOfShareIn, objNew.TotalOfLikes,
                objNew.TotalOfViews, (byte)objNew.Rank, objNew.ModifiedBy, objNew.ModifiedTime, objNew.isApproved, objNew.ApprovedBy, objNew.isDeleted);
        }

    }
}
