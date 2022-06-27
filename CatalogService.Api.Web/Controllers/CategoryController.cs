using AutoMapper;
using CatalogService.Api.BLL.Services;
using CatalogService.Api.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogService.Api.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private ICategoryService categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }
        // GET: api/<CateroryController>
        [HttpGet()]
        [Route("ListCategories")]
        public IEnumerable<Category> ListCategories()
        {
            var categories = categoryService.GetAll();
            var categoriesUI = mapper.Map<IList<Category>>(categories);
            return categoriesUI;
        }

        // GET api/<CateroryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = categoryService.GetById(id);
            var categoryBs = mapper.Map<Category>(category);
            return categoryBs;
        }

        // POST api/<CateroryController>
        [HttpPost]
        [Route("AddCategory")]
        public ActionResult<Category> AddCategory(CategoryUpdate dto)
        {
            var categoryBs = mapper.Map<Api.BLL.Models.Category>(dto);
            categoryService.Insert(categoryBs);
            return Ok();
        }

        // POST api/<CateroryController>
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(CategoryUpdate dto)
        {
            var categoryBs = mapper.Map<Api.BLL.Models.Category>(dto);
            categoryService.Update(categoryBs);
            return Ok(categoryBs);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
