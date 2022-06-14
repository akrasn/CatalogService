using CatalogService.Api.BLL.ModelBS;
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
        private IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet()]
        public IEnumerable<ProductBS> Get()
        {
            return productService.GetAll();
        }

        [HttpGet("{id}")]
        public ProductBS Get(int id)
        {
            return productService.GetById(id);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<ProductBS> Insert(ProductBS dto)
        {
            productService.Insert(dto);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<ProductBS> Update(ProductBS dto)
        {
            productService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductBS> Delete(int id)
        {
            var product = productService.GetById(id);
            productService.Delete(product);
            return Ok();
        }
    }
}
