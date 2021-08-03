using System;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Product: IDatabaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCategoryId { get; set; }
        public string ProductTypeId { get; set; }
        public string ProductSizeId { get; set; }
        public decimal Price { get; set; }
        public string Tags { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}