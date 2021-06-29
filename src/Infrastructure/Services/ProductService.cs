using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class ProductService
    {
        private readonly string _connectionString;
        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DataBaseConnection");
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Product>("SELECT * FROM Products WITH (NOLOCK)");
                return response.ToList();
            }
        }

        public async Task<List<ProductReport>> GetProductsToReportAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string procedureName = "SelectProducts";
                var response = await connection.QueryAsync<ProductReport>(procedureName, commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Product>("SELECT * FROM Products WITH (NOLOCK) WHERE Id = @id", new { id });
                return response.FirstOrDefault();
            }
        }
    
        public async Task CreateProductAsync(Product product) {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string procedureName = "InsertProduct";
                var values = new {
                    Name = product.Name,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    SubCategoryId = product.SubCategoryId,
                    TypeId = product.TypeId,
                    ModelId = product.ModelId,
                    Price = product.Price,
                    Description = product.Description,
                    UpdatedBy = product.UpdatedBy
                };
                await connection.ExecuteAsync(procedureName, values, commandType: CommandType.StoredProcedure);
            }
        }
    
        public async Task UpdateProductAsync(Product product)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string procedureName = "UpdateProduct";
                var values = new {
                    Id = product.Id,
                    Name = product.Name,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    SubCategoryId = product.SubCategoryId,
                    TypeId = product.TypeId,
                    ModelId = product.ModelId,
                    Price = product.Price,
                    Description = product.Description,
                    UpdatedBy = product.UpdatedBy
                };
                
                await connection.ExecuteAsync(procedureName, values, commandType: CommandType.StoredProcedure);
            }
        }
    
        public async Task DeleteProductAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection
                .QueryAsync("DELETE FROM Products WHERE id = @Id", new { Id = id });
            }
        }
    }
}