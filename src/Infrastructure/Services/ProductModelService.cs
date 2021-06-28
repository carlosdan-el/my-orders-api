using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class ProductModelService
    {
        private readonly string _connectionString;
        public ProductModelService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DataBaseConnection");
        }

        public async Task<List<ProductModel>> GetProductsModelsAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<ProductModel>("SELECT * FROM ProductModel WITH (NOLOCK)");
                return response.ToList();
            }
        }

        public async Task<List<ProductModel>> GetProductsModelsByTypeIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection
                .QueryAsync<ProductModel>("SELECT * FROM ProductModel WITH (NOLOCK) WHERE ProductTypeId = @id", new { id });
                return response.ToList();
            }
        }
    }
}