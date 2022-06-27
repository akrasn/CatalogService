using CatalogService.Api.DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;

namespace CatalogService.Api.DAL.Repositories.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        IList<Product> GetCategory(int categoryId, int pageNumber, int pageSize);

        int CategoryCount(int categoryId);
        public void Delete(int id);
    }
}
