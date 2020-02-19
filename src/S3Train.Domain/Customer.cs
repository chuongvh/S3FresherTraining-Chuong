using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Train.Domain
{
    public class Customer : EntityBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ShipAddress { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
