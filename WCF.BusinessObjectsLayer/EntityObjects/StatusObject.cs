using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class StatusObject
    {
        public int StatusID { get; set; }
        public String StatusName { get; set; }
        public static StatusObject LEVEL_0 = new StatusObject()
        {
            StatusID = 0,
            StatusName = "Bài mới chờ duyệt"
        };
        public static StatusObject LEVEL_1 = new StatusObject()
        {
            StatusID = 1,
            StatusName = "Đã được duyệt"
        };
        public static StatusObject LEVEL_2 = new StatusObject()
        {
            StatusID = 2,
            StatusName = "Đã xem và không được duyệt"
        };
        public static StatusObject LEVEL_3 = new StatusObject()
        {
            StatusID = 3,
            StatusName = "Đã sửa và đang chờ duyệt"
        };
    }
}
