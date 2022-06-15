using AutoMapper;
using CatalogService.Api.BLL.Models;
using DAL.Repositories;
using System.Collections.Generic;

namespace CatalogService.Api.BLL.Services
{
    public class ProductService : IProductService
    {
        private IGenericRepository<DAL.Entities.Product> productRepository;
        private readonly IMapper mapper;
        public ProductService(IMapper mapper, IGenericRepository<DAL.Entities.Product> productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public void Delete(Product entity, bool saveChanges = true)
        {
            var product = mapper.Map<DAL.Entities.Product>(entity);
            productRepository.Delete(product, saveChanges);
        }

        public IList<Product> GetAll()
        {
            var products = productRepository.GetAll();
            var productBs = mapper.Map<IList<Product>>(products);
            return productBs;
        }

        public Product GetById(int id)
        {
            var product = productRepository.GetById(id);
            var productBs = mapper.Map<Product>(product);
            return productBs;
        }

        public void Insert(Product entity, bool saveChanges = true)
        {
            var product = mapper.Map<DAL.Entities.Product>(entity);
            productRepository.Insert(product, saveChanges);
        }

        public void Update(Product entity, bool saveChanges = true)
        {
            var product = mapper.Map<DAL.Entities.Product>(entity);
            productRepository.Update(product, saveChanges);
        }
    }
}
