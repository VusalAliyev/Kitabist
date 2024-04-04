using AutoMapper;
using Kitabist.Catalog.Dtos.Category;
using Kitabist.Catalog.Dtos.Product;
using Kitabist.Catalog.Entities;

namespace Kitabist.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        protected GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetAllProductDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, GetProductByIdDto>().ReverseMap();
            CreateMap<Product, GetAllProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

        }
    }
}
