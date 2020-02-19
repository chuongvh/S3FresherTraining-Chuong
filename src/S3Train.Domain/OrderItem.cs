using System.ComponentModel.DataAnnotations.Schema;

namespace S3Train.Domain
{
    public class OrderItem : EntityBase
    {
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}