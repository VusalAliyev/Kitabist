using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Kitabist.Catalog.Dtos.Product
{
    public class GetAllProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Page { get; set; }
        public string Author { get; set; }
        public int MyProperty { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }

        public string CategoryId { get; set; }
    }
}
