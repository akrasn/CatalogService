using AutoMapper;
using CatalogService.Api.BLL.Models;
using CatalogService.Api.DAL.Repositories.Interface;
using DAL.Repositories;
using System.Collections.Generic;

namespace CatalogService.Api.BLL.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public void Delete(int id)
        {
            productRepository.Delete(id);
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

        public void Insert(Product entity)
        {
            var product = mapper.Map<DAL.Entities.Product>(entity);
            productRepository.Insert(product);
        }

        public void Update(Product entity)
        {
            var product = mapper.Map<DAL.Entities.Product>(entity);
            productRepository.Update(product);
        }

        public IList<Product> GetCategory(int categoryId, int pageNumber, int pageSize)
        {
            var productsContext = productRepository.GetCategory(categoryId, pageNumber, pageSize);
            var products = mapper.Map<IList<Product>>(productsContext);
            return products;
        }

        public int CategoryCount(int categoryId)
        {
            return productRepository.CategoryCount(categoryId);
        }
    }
}
