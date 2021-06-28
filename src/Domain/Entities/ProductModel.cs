using System;

namespace Domain.Entities
{
    public class ProductModel
    {
        public string Id { get; set; }
      public string Name { get; set; }
      public string CategoryId { get; set; }
      public string SubCategoryId { get; set; }
      public string ProductTypeId { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
      public string UpdatedBy { get; set; }
    }
}