using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class TechCommentReplyObject
    {
        public Guid TechCommentReplyID { get; set; }
        public Guid TechCommentID { get; set; }
        public Guid ReplyBy { get; set; }
        public AccountObject objReplyBy { get; set; }
        public String ContentReply { get; set; }
        public DateTime MofifiedTime { get; set; }
        public bool isDeleted { get; set; }
    }
}
