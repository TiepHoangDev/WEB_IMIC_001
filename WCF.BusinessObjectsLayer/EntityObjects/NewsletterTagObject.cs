﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BusinessObjectsLayer.EntityObjects
{
    public class NewsletterTagObject
    {
        public Guid NewsletterTagId { get; set; }
        public String NewsletterTagName { get; set; }
        public int TotalOfNewsletter { get; set; }
    }
}
