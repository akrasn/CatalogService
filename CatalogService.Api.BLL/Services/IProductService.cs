using CatalogService.Api.BLL.ModelBS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Api.BLL.Services
{
    public interface IProductService
    {
        IList<ProductBS> GetAll();
        ProductBS GetById(int id);
        void Insert(ProductBS entity, bool saveChanges = true);
        void Delete(ProductBS entity, bool saveChanges = true);
        void Update(ProductBS entity, bool saveChanges = true);
    }
}
