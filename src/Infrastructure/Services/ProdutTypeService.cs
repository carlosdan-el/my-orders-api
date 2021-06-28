using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class ProductTypeService
    {
        private readonly string _connectionString;

        public ProductTypeService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DataBaseConnection");
        }
    
        public async Task<List<ProductType>> GetProductsTypesAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<ProductType>("SELECT * FROM ProductType WITH (NOLOCK)");
                return response.ToList();
            }
        }
    
        public async Task<List<ProductType>> GetBySubCategoryIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection
                .QueryAsync<ProductType>("SELECT * FROM ProductType WITH (NOLOCK) WHERE SubCategoryId = @id", new { id });
                return response.ToList();
            }
        }
    }
}