using System.Collections.Generic;

namespace CatalogService.Api.Web
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ParentCategoryId { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
