using AutoMapper;
using CatalogService.Api.BLL.ModelBS;
using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;

namespace CatalogService.Api.BLL.Services
{
    public class ProductService : IProductService
    {
        private IGenericRepository<Product> productRepository;
        private readonly IMapper mapper;
        public ProductService(IMapper mapper, IGenericRepository<Product> productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public void Delete(ProductBS entity, bool saveChanges = true)
        {
            var product = mapper.Map<Product>(entity);
            productRepository.Delete(product, saveChanges);
        }

        public IList<ProductBS> GetAll()
        {
            var products = productRepository.GetAll();
            var productBs = mapper.Map<IList<ProductBS>>(products);
            return productBs;
        }

        public ProductBS GetById(int id)
        {
            var product = productRepository.GetById(id);
            var productBs = mapper.Map<ProductBS>(product);
            return productBs;
        }

        public void Insert(ProductBS entity, bool saveChanges = true)
        {
            var product = mapper.Map<Product>(entity);
            productRepository.Insert(product, saveChanges);
        }

        public void Update(ProductBS entity, bool saveChanges = true)
        {
            var product = mapper.Map<Product>(entity);
            productRepository.Update(product, saveChanges);
        }
    }
}
