using System;

namespace Domain.Entities
{
    public class ProductReport
    {
        public string Id { get; set;}
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}