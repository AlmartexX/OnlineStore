namespace OnlineStore.DAL.Context.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
