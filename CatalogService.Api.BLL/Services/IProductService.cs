using CatalogService.Api.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.BLL.Services
{
    public interface IProductService
    {
        IList<Product> GetAll();

        IList<Product> GetCategory(int categoryId, int pageNumber, int pageSize);
        int CategoryCount(int categoryId);
        Product GetById(int id);
        void Insert(Product entity);
        void Delete(int id);
        void Update(Product entity);
    }
}
