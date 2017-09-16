using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class CommentReplyObject
    {
        public System.Guid CommentReplyId { get; set; }
        public Nullable<System.Guid> CommentId { get; set; }
        public Nullable<System.Guid> ReplyBy { get; set; }
        public string ContentReply { get; set; }
        public Nullable<int> TotalOfLikes { get; set; }
        public Nullable<int> TotalOfDislikes { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public AccountObject objUser { get; set; }
        public bool IsLiked { get; set; }
    }
}
