using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Api.Web.Filter
{
    public class ProductPaginationFilter : PaginationFilter
    {
        public int CategoryId { get; set; }
    }
}
