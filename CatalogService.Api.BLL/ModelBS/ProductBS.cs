namespace CatalogService.Api.BLL.ModelBS
{
    public class ProductBS
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryBS Category { get; set; }
        public decimal Price { get; set; }
        public uint Amount { get; set; }

    }
}