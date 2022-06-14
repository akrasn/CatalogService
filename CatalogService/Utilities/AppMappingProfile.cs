using AutoMapper;
using CatalogService.Api.BLL.ModelBS;
using CatalogService.Api.BLL.ModelUI;
using DAL.Entities;

namespace CatalogService.Api.Web.Utilities
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Category, CategoryBS>().ReverseMap();
            CreateMap<Product, ProductBS>().ForMember(x => x.Category, opt => opt.Ignore()).ForMember(x => x.CategoryId, opt => opt.Ignore()).ReverseMap();
            CreateMap<CategoryBS, CategoryUI>().ReverseMap();
            CreateMap<ProductBS, ProductUI>().ForMember(x => x.Category, opt => opt.Ignore()).ForMember(x => x.CategoryId, opt => opt.Ignore()).ReverseMap();
        }
    }
}
