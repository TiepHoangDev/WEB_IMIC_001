using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class FacebookUserLikedObject
    {
        public Guid FacebookUserLikedId { get; set; }
        public string FacebookAvatar { get; set; }
        public string FacebookName { get; set; }
        public string FacebookLink { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsShow { get; set; }
        public int?  RankVip { get; set; }
    }
}
