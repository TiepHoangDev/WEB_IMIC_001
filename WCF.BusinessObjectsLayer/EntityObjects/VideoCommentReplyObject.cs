using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class VideoCommentReplyObject
    {
        public Guid VideoCommentReplyId { get; set; }
        public Guid VideoCommentId { get; set; }
        public Guid ReplyBy { get; set; }
        public string ContentReply { get; set; }
        public int TotalOfLikes { get; set; }
        public int TotalOfDislikes { get; set; }
        public DateTime ModifiedTime { get; set; }
        public AccountObject Account { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLiked { get; set; }
    }
}
