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
        Product GetById(int id);
        void Insert(Product entity, bool saveChanges = true);
        void Delete(Product entity, bool saveChanges = true);
        void Update(Product entity, bool saveChanges = true);
    }
}
