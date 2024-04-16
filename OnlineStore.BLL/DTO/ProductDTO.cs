
namespace OnlineStore.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        public ICollection<CategoryDTO> categories { get; set; }
    }
}
