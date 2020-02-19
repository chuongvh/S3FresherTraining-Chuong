namespace S3Train.Domain
{
    public class OrderItem :EntityBase
    {
        public string OrderId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}