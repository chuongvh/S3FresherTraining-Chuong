﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Order : EntityBase
    {
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ApplicationUser IdentityUser { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
