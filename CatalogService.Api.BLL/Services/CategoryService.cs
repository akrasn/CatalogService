using AutoMapper;
using CatalogService.Api.BLL.Models;
using DAL.Repositories;
using System.Collections.Generic;

namespace CatalogService.Api.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }

        public IList<Category> GetAll()
        {
            var categories = categoryRepository.GetAll();
            var categoriesBs = mapper.Map<IList<Category>>(categories);
            return categoriesBs;
        }

        public Category GetById(int id)
        {
            var category = categoryRepository.GetById(id);
            var categoryBs = mapper.Map<Category>(category);
            return categoryBs;
        }

        public void Insert(Category entity)
        {
            var category = mapper.Map<DAL.Entities.Category>(entity);
            categoryRepository.Insert(category);
        }

        public void Update(Category entity)
        {
            var category = mapper.Map<DAL.Entities.Category>(entity);
            categoryRepository.Update(category);
        }
    }
}
