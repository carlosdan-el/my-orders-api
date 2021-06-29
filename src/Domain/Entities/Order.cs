using System;

namespace Domain.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }   
    }
}