using System.Collections.Generic;

namespace CatalogService.Api.BLL.ModelUI
{
    public class CategoryUI
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ParentCategoryId { get; set; }
        public ICollection<ProductUI> Products { get; set; }
    }
}
