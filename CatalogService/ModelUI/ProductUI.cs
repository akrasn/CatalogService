namespace CatalogService.Api.BLL.ModelUI
{
    public class ProductUI
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryUI Category { get; set; }
        public decimal Price { get; set; }
        public uint Amount { get; set; }
    }
}