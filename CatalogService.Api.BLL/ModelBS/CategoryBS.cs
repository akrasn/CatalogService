using System.Collections.Generic;

namespace CatalogService.Api.BLL.ModelBS
{
    public class CategoryBS
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ParentCategoryId { get; set; }
        public ICollection<ProductBS> Products { get; set; }
    }
}
