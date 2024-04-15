namespace OnlineStore.DAL.Entities
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }  
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
