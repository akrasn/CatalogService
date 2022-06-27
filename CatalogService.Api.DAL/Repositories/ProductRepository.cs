using CatalogService.Api.DAL.Entities;
using CatalogService.Api.DAL.Repositories.Interface;
using DAL.DataContext;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private StoreDataContext storeDBContext;
        public ProductRepository(StoreDataContext context)
            : base(context)
        {
            storeDBContext = context;
        }

        public int CategoryCount(int categoryId)
        {
            return storeDBContext.Products.Count();
        }

        public override IList<Product> GetAll()
        {
            var result = storeDBContext.Products.ToList();
            return result;
        }

        public void Delete(int id)
        {
            var product = new Product() { ProductId = id };
            storeDBContext.Products.Attach(product);
            storeDBContext.Products.Remove(product);
            storeDBContext.SaveChanges();
        }

        public IList<Product> GetCategory(int categoryId, int pageNumber, int pageSize)
        {
             var pagedData = storeDBContext.Products.Where(_=>_.CategoryId == categoryId)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToList();
            //var totalRecords = storeDBContext.Products.Count();
            return pagedData;
        }
    }
}
