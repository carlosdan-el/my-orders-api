using System;

namespace Domain.Entities
{
    public class ProductType
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}