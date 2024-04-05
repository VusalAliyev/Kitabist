using Kitabist.Catalog.Dtos.ProductImage;

namespace Kitabist.Catalog.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<List<GetAllProductImage>> GetAllProductImagesAsync();
        Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
    }
}
