using AutoMapper;

namespace CatalogService.Api.Web.Utilities
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DAL.Entities.Category, BLL.Models.Category>().ReverseMap();
            CreateMap<DAL.Entities.Product, BLL.Models.Product>().ForMember(x => x.Category, opt => opt.Ignore()).ForMember(x => x.CategoryId, opt => opt.Ignore()).ReverseMap();
            CreateMap<Category, BLL.Models.Category>().ReverseMap();
            CreateMap<Product, BLL.Models.Product>().ForMember(x => x.Category, opt => opt.Ignore()).ForMember(x => x.CategoryId, opt => opt.Ignore()).ReverseMap();
        }
    }
}
