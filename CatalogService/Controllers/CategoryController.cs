using AutoMapper;
using CatalogService.Api.BLL.ModelBS;
using CatalogService.Api.BLL.ModelUI;
using CatalogService.Api.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Web;

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
        public IEnumerable<CategoryUI> Get()
        {
            var categories = categoryService.GetAll();
            var categoriesUI = mapper.Map<IList<CategoryUI>>(categories);
            return categoriesUI;
        }

        // GET api/<CateroryController>/5
        [HttpGet("{id}")]
        public CategoryUI Get(int id)
        {
            var category = categoryService.GetById(id);
            var categoryBs = mapper.Map<CategoryUI>(category);
            return categoryBs;
        }

        // POST api/<CateroryController>
        [HttpPost]
        [Route("add")]
        public ActionResult<CategoryUI> Insert(CategoryUI dto)
        {
            var categoryBs = mapper.Map<CategoryBS>(dto);
            categoryService.Insert(categoryBs);
            return Ok();
        }

        // POST api/<CateroryController>
        [HttpPost]
        [Route("update")]
        public IActionResult Update(CategoryUI dto)
        {
            var categoryBs = mapper.Map<CategoryBS>(dto);
            categoryService.Update(categoryBs);
            return Ok(categoryBs);
        }

        [HttpDelete("{id}")]
        public ActionResult<CategoryUI> Delete(int id)
        {
            categoryService.Delete(id);
            return Ok();
        }
    }
}
