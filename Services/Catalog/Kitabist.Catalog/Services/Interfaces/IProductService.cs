using Kitabist.Catalog.Dtos.Product;

namespace Kitabist.Catalog.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<GetAllProductDto>> GetAllProductDtosAsync();
        Task<GetProductByIdDto> GetProductByIdAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);

    }
}
