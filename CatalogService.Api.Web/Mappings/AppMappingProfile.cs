using AutoMapper;
using CatalogService.Api.Web.Models;

namespace CatalogService.Api.Web.Utilities
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DAL.Entities.Category, BLL.Models.Category>().ReverseMap();
            
            CreateMap<DAL.Entities.Product, BLL.Models.Product>().ReverseMap();
            CreateMap<BLL.Models.Product, ProductList>();
            CreateMap<Category, BLL.Models.Category>()
                .ForMember(dst => dst.Products, opt => opt.MapFrom(src => src.ProductList))
                .ReverseMap();
            CreateMap<CategoryUpdate, BLL.Models.Category>().ReverseMap();
            CreateMap<Product, BLL.Models.Product>().ReverseMap();
            CreateMap<ProductUpdate, BLL.Models.Product>().ForMember(x => x.Category, opt => opt.Ignore()).ReverseMap();
        }
    }
}
