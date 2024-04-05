using AutoMapper;
using Kitabist.Catalog.Dtos.ProductDetail;
using Kitabist.Catalog.Entities;
using Kitabist.Catalog.Services.Interfaces;
using Kitabist.Catalog.Settings;
using MongoDB.Driver;

namespace Kitabist.Catalog.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(d => d.ProductDetailId == id);
        }

        public async Task<List<GetAllProductDetailDto>> GetAllProductDetailsAsync()
        {
            var productDetails = await _productDetailCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<GetAllProductDetailDto>>(productDetails);
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByIdAsync(string id)
        {
            var productDetail = await _productDetailCollection.Find<ProductDetail>(d => d.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDetailByIdDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.ReplaceOneAsync(d => d.ProductDetailId == updateProductDetailDto.ProductDetailId, productDetail);
        }
    }
}
