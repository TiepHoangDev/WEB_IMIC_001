using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class ContactDao : BaseModel<ContactObject>
    {
        private static WebIMicEntities m_objDb = new WebIMicEntities();

        public List<ContactObject> getAll()
        {
            var lisGet = m_objDb.WEB_IMIC_SP_Contact_GetAll().ToList();

            List<ContactObject> lisRs = new List<ContactObject>();

            foreach (var item in lisGet)
            {
                ContactObject objContact = new ContactObject();
                objContact.ContactId = item.ContactId;
                objContact.FullName = item.FullName;
                objContact.Email = item.Email;
                objContact.Title = item.Title;
                objContact.ContentContact = item.ContentContact;
                objContact.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objContact.IsSeen = item.IsSeen.GetValueOrDefault();
                objContact.IsDeleted = item.IsDeleted;
                lisRs.Add(objContact);
            }
            return lisRs;
        }

        public List<ContactObject> getUnseen()
        {
            var lisGet = m_objDb.WEB_IMIC_SP_Contact_GetUnseenContact().ToList();

            List<ContactObject> lisRs = new List<ContactObject>();

            foreach (var item in lisGet)
            {
                ContactObject objContact = new ContactObject();
                objContact.ContactId = item.ContactId;
                objContact.FullName = item.FullName;
                objContact.Email = item.Email;
                objContact.Title = item.Title;
                objContact.ContentContact = item.ContentContact;
                objContact.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objContact.IsSeen = item.IsSeen.GetValueOrDefault();
                objContact.IsDeleted = item.IsDeleted;
                lisRs.Add(objContact);
            }
            return lisRs;
        }

        public ContactObject GetById(Guid ContactId)
        {
            var lisGet = m_objDb.WEB_IMIC_SP_Contact_GetById(ContactId).ToList();

            List<ContactObject> lisRs = new List<ContactObject>();

            foreach (var item in lisGet)
            {
                ContactObject objContact = new ContactObject();
                objContact.ContactId = item.ContactId;
                objContact.FullName = item.FullName;
                objContact.Email = item.Email;
                objContact.Title = item.Title;
                objContact.ContentContact = item.ContentContact;
                objContact.CreatedTime = item.CreatedTime.GetValueOrDefault();
                objContact.IsSeen = item.IsSeen.GetValueOrDefault();
                objContact.IsDeleted = item.IsDeleted;
                lisRs.Add(objContact);
            }
            return lisRs.First();
        }

        public bool Insert(ContactObject objContact)
        {
            m_objDb.WEB_IMIC_SP_Contact_update(objContact.ContactId, objContact.FullName, objContact.Email, objContact.Title,
                objContact.ContentContact, objContact.CreatedTime,objContact.IsSeen, objContact.IsDeleted, false);
            return true;
        }

        public bool Update(ContactObject objContact)
        {
            m_objDb.WEB_IMIC_SP_Contact_update(objContact.ContactId, objContact.FullName, objContact.Email, objContact.Title,
                objContact.ContentContact, objContact.CreatedTime, objContact.IsSeen, objContact.IsDeleted, true);
            return true;
        }

        public bool MarkAsRead(Guid ContactId)
        {
            m_objDb.WEB_IMIC_SP_Contact_SeenContact(ContactId);
            return true;
        }
    }
}
