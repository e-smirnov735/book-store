namespace Store.Web.Models
{
    public class OrderItemModel
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
