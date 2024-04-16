namespace OnlineStore.DAL.Entities
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public DateOnly Birthdate { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
