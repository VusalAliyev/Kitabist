using Kitabist.Catalog.Dtos.Category;
using Kitabist.Catalog.Dtos.Product;
using Kitabist.Catalog.Dtos.ProductDetail;
using Kitabist.Catalog.Services;
using Kitabist.Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitabist.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productServices;

        public ProductsController(IProductService productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productServices.GetAllProductDtosAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product=await _productServices.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return Ok("Product Added");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productServices.DeleteProductAsync(id);
            return Ok("Product Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return Ok("Product Updated");
        }

    }
}
