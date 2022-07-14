using AutoMapper;
using CatalogService.Api.BLL.Services;
using CatalogService.Api.Web.Filter;
using CatalogService.Api.Web.Helpers;
using CatalogService.Api.Web.Models;
using CatalogService.Api.Web.Producer;
using CatalogService.Api.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IUriService uriService;

        public ProductController(IMapper mapper, ILogger<ProductController> logger, IProductService productService, IUriService uriService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.productService = productService;
            this.uriService = uriService;
        }

        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            var products = productService.GetAll();
            return mapper.Map<IList<Product>>(products);
        }

        [HttpGet]
        [Route("ListOfItem")]
        public IActionResult ListOfItem([FromQuery] ProductPaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var products = productService.GetCategory(filter.CategoryId, filter.PageNumber, filter.PageSize);
            var totalRecords = productService.CategoryCount(filter.CategoryId);
            var pagedData = mapper.Map<IList<Product>>(products);
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData.ToList(), validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = productService.GetById(id);
            var productUI = mapper.Map<Product>(product);
            return productUI;
        }

        [HttpPost]
        [Route("AddItem")]
        public ActionResult<ProductUpdate> AddItem(ProductUpdate dto)
        {
            var Product = mapper.Map<Api.BLL.Models.Product>(dto);
            productService.Insert(Product);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async System.Threading.Tasks.Task<ActionResult<ProductUpdate>> UpdateItemAsync(ProductUpdate dto)
        {
            var product = mapper.Map<BLL.Models.Product>(dto);
            productService.Update(product);
            var productMessage = mapper.Map<ProductMessage>(product);
            var message = new KafkaProducer();
            await message.KafkaMessage(productMessage);
            return Ok();
        }

        [HttpDelete("DeleteItem/{id}")]
        public ActionResult<Product> DeleteItem(int id)
        {
            productService.Delete(id);
            return Ok();
        }
    }
}
