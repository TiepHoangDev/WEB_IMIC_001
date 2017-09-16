using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class StudentGaleryBcl
    {
        public List<StudentGaleryObject> getElements()
        {
            return new StudentGaleryDao().getElements();
        }
        public void addElements(StudentGaleryObject objStudent)
        {
            new StudentGaleryDao().addElements(objStudent);
        }
        public void updateElements(StudentGaleryObject objStudent)
        {
            new StudentGaleryDao().updateElements(objStudent);
        }
        public StudentGaleryObject getElementByID(Guid id)
        {
            return new StudentGaleryDao().getElementsById(id);
        }
        public void deleteElement(Guid id)
        {
            new StudentGaleryDao().deleteElement(id);
        }
    }
}
