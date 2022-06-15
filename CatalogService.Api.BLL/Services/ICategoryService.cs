using CatalogService.Api.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.BLL.Services
{
    public interface ICategoryService
    {
        IList<Category> GetAll();
        Category GetById(int id);
        void Insert(Category entity, bool saveChanges = true);
        void Delete(Category entity, bool saveChanges = true);
        void Delete(int id);
        void Update(Category entity, bool saveChanges = true);
    }
}
