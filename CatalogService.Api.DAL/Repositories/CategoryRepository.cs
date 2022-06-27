using CatalogService.Api.DAL.Entities;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private StoreDataContext storeDBContext;
        public CategoryRepository(StoreDataContext context)
            : base(context)
        {
            storeDBContext = context;
        }

        public override Category GetById(int id)
        {
            var result = storeDBContext.Category.Include(x => x.Products).FirstOrDefault(x => x.CategoryId == id);
            return result;
        }

        public override IList<Category> GetAll()
        {
            var result = storeDBContext.Category.Include(x => x.Products).ToList();
            return result;
        }

        public void Delete(int id)
        {
            var category = new Category() { CategoryId = id };
            var products = storeDBContext.Products.Where(_=>_.CategoryId == id);
            foreach (var product in products)
            {
                storeDBContext.Products.Attach(product);
                storeDBContext.Products.Remove(product);
            }
            storeDBContext.Category.Attach(category);
            storeDBContext.Category.Remove(category);
            storeDBContext.SaveChanges();
        }
    }
}
