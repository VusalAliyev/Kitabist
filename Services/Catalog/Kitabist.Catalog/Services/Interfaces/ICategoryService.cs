using Kitabist.Catalog.Dtos.Category;
using Kitabist.Catalog.Dtos.Product;

namespace Kitabist.Catalog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoryDto>> GetAllCategoriesAsync();  
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
