using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class ContactPageBcl
    {
        public List<ContactObject> GetAll()
        {
            return new ContactDao().getAll();
        }
        public List<ContactObject> GetUnseenContact()
        {
            return new ContactDao().getUnseen();
        }
        public ContactObject GetById(Guid ContactId)
        {
            return new ContactDao().GetById(ContactId);
        }
        public bool Insert(ContactObject objContact)
        {
            return new ContactDao().Insert(objContact);
        }
        public bool MarkAsRead(Guid ContactId)
        {
            return new ContactDao().MarkAsRead(ContactId);
        }
    }
}
