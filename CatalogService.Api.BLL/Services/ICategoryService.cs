using CatalogService.Api.BLL.ModelBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.BLL.Services
{
    public interface ICategoryService
    {
        IList<CategoryBS> GetAll();
        CategoryBS GetById(int id);
        void Insert(CategoryBS entity, bool saveChanges = true);
        void Delete(CategoryBS entity, bool saveChanges = true);
        void Delete(int id);
        void Update(CategoryBS entity, bool saveChanges = true);
    }
}
