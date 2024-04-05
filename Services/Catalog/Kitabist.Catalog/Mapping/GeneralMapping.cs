using AutoMapper;
using Kitabist.Catalog.Dtos.Category;
using Kitabist.Catalog.Dtos.Product;
using Kitabist.Catalog.Dtos.ProductDetail;
using Kitabist.Catalog.Dtos.ProductImage;
using Kitabist.Catalog.Entities;

namespace Kitabist.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetAllCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, GetProductByIdDto>().ReverseMap();
            CreateMap<Product, GetAllProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<ProductDetail, GetProductDetailByIdDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetAllProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, GetProductImageByIdDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetAllProductImage>().ReverseMap();

        }
    }
}
