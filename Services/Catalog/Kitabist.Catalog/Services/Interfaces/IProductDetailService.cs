using Kitabist.Catalog.Dtos.ProductDetail;

namespace Kitabist.Catalog.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<List<GetAllProductDetailDto>> GetAllProductDetailsAsync();
        Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string id);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
    }
}
