using AutoMapper;
using Kitabist.Catalog.Dtos.Category;
using Kitabist.Catalog.Entities;
using Kitabist.Catalog.Services.Interfaces;
using Kitabist.Catalog.Settings;
using MongoDB.Driver;
using System.Security.Principal;

namespace Kitabist.Catalog.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(id);
        }

        public async Task<List<GetAllCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryCollection.Find(c => true).ToListAsync();
            var mappedCategories = _mapper.Map<List<GetAllCategoryDto>>(categories);
            return mappedCategories;
        }

        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id)
        {
            var category = await _categoryCollection.FindAsync(c => c.CategoryId == id);
            var mappedCategory=_mapper.Map<GetCategoryByIdDto>(category);
            return mappedCategory;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = await _categoryCollection.Find(c => c.CategoryId == updateCategoryDto.CategoryId).FirstOrDefaultAsync();
            var mappedCategory = _mapper.Map<Category>(updatedCategory);
            _categoryCollection.ReplaceOne(c=>c.CategoryId==updateCategoryDto.CategoryId, mappedCategory);

        }
    }
}
