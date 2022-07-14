using AutoMapper;
using CatalogService.Api.Web.Models;
using CatalogService.Api.Web.Producer;

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
            CreateMap<ProductMessage, BLL.Models.Product>()
                .ForMember(dst => dst.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.ImageUrl,opt =>opt.MapFrom(src =>src.Image))
                .ForMember(dst => dst.Category, opt => opt.Ignore())
                .ForMember(dst => dst.CategoryId, opt => opt.Ignore())
                .ForMember(dst => dst.Amount, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
