using AutoMapper;
using Kitabist.Catalog.Dtos.ProductImage;
using Kitabist.Catalog.Entities;
using Kitabist.Catalog.Services.Interfaces;
using Kitabist.Catalog.Settings;
using MongoDB.Driver;

namespace Kitabist.Catalog.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(productImage);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(i => i.ProductImagesID == id);
        }

        public async Task<List<GetAllProductImage>> GetAllProductImagesAsync()
        {
            var productImages = await _productImageCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<GetAllProductImage>>(productImages);
        }

        public async Task<GetProductImageByIdDto> GetProductImageByIdAsync(string id)
        {
            var productImage = await _productImageCollection.Find<ProductImage>(i => i.ProductImagesID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageByIdDto>(productImage);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.ReplaceOneAsync(i => i.ProductImagesID == updateProductImageDto.ProductImagesID, productImage);
        }
    }
}
