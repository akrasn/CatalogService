using AutoMapper;
using CatalogService.Api.BLL.Services;
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
        public IEnumerable<Category> Get()
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
        public ActionResult<Category> Insert(Category dto)
        {
            var categoryBs = mapper.Map<Api.BLL.Models.Category>(dto);
            categoryService.Insert(categoryBs);
            return Ok();
        }

        // POST api/<CateroryController>
        [HttpPut]
        public IActionResult Update(Category dto)
        {
            var categoryBs = mapper.Map<Api.BLL.Models.Category>(dto);
            categoryService.Update(categoryBs);
            return Ok(categoryBs);
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
