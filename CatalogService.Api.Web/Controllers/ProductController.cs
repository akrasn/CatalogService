using AutoMapper;
using CatalogService.Api.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogService.Api.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IMapper mapper;
        private IProductService productService;

        public ProductController(IMapper mapper, ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.productService = productService;
        }

        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            var products = productService.GetAll();
            return mapper.Map<IList<Product>>(products);
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = productService.GetById(id);
            var productUI = mapper.Map<Product>(product);
            return productUI;
        }

        [HttpPost]
        public ActionResult<Product> Insert(Product dto)
        {
            var Product = mapper.Map<Api.BLL.Models.Product>(dto);
            productService.Insert(Product);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Product> Update(Product dto)
        {
            var categoryBs = mapper.Map<Api.BLL.Models.Product>(dto);
            productService.Update(categoryBs);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = productService.GetById(id);
            productService.Delete(product);
            return Ok();
        }
    }
}
