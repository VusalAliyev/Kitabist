using MongoDB.Bson.Serialization.Attributes;

namespace Kitabist.Catalog.Dtos.ProductDetail
{
    public class CreateProductDetailDto
    {
        public string ProductDescription { get; set; }
        public int Page { get; set; }
        public string ProductID { get; set; }
    }
}
