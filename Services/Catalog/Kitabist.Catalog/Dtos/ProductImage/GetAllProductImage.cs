using MongoDB.Bson.Serialization.Attributes;

namespace Kitabist.Catalog.Dtos.ProductImage
{
    public class GetAllProductImage
    {
        public string ProductImagesID { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductID { get; set; }
    }
}
