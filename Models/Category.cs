namespace E_Ticaret.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Varsayılan değer atanıyor
        public List<Product> Products { get; set; } = new List<Product>(); // Varsayılan değer atanıyor
    }
}
