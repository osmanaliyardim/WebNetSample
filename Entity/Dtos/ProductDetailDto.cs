using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos
{
    public class ProductDetailDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
    }
}