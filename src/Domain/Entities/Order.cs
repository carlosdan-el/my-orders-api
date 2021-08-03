using System;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Order: IDatabaseEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}