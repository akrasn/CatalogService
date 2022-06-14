using AutoMapper;
using CatalogService.Api.BLL.ModelBS;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Delete(CategoryBS entity, bool saveChanges = true)
        {
            var category = mapper.Map<Category>(entity);
            categoryRepository.Delete(category, saveChanges);
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }

        public IList<CategoryBS> GetAll()
        {
            var categories = categoryRepository.GetAll();
            var categoriesBs = mapper.Map<IList<CategoryBS>>(categories);
            return categoriesBs;
        }

        public CategoryBS GetById(int id)
        {
            var category = categoryRepository.GetById(id);
            var categoryBs = mapper.Map<CategoryBS>(category);
            return categoryBs;
        }

        public void Insert(CategoryBS entity, bool saveChanges = true)
        {
            var category = mapper.Map<Category>(entity);
            categoryRepository.Insert(category, saveChanges);
        }

        public void Update(CategoryBS entity, bool saveChanges = true)
        {
            var category = mapper.Map<Category>(entity);
            categoryRepository.Update(category, saveChanges);
        }
    }
}
