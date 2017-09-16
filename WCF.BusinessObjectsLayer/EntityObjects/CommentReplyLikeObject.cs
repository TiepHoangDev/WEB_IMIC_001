using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
   public class CommentReplyLikeObject
    {
       public Guid CommentReplyLikeId { get; set; }
       public Guid CommentReplyId { get; set; }
       public Guid LikedBy { get; set; }
       public DateTime CreatedTime { get; set; }
    }
}
