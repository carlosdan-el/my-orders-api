using System;

namespace Domain.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BrandId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string TypeId { get; set; }
        public string ModelId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}