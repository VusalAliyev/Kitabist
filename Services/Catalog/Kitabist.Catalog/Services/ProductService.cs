using AutoMapper;
using Kitabist.Catalog.Dtos.Category;
using Kitabist.Catalog.Dtos.Product;
using Kitabist.Catalog.Entities;
using Kitabist.Catalog.Services.Interfaces;
using Kitabist.Catalog.Settings;
using MongoDB.Driver;

namespace Kitabist.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection; 
        public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database=client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var mappedProducts = _mapper.Map<Product>(createProductDto);
           await _productCollection.InsertOneAsync(mappedProducts);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(p=>p.ProductId == id);
        }

        public async Task<List<GetAllProductDto>> GetAllProductDtosAsync()
        {
            var products=await _productCollection.Find(p=> true).ToListAsync();   
            var mappedProducts=_mapper.Map<List<GetAllProductDto>>(products);
            return mappedProducts;
        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            var product = await _productCollection.Find(c => c.ProductId == id).FirstOrDefaultAsync();
            var mappedProduct = _mapper.Map<GetProductByIdDto>(product);
            return mappedProduct;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {

            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
