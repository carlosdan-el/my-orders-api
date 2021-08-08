using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductCategoryService
    {
        private readonly string _connectionString;
        public ProductCategoryService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DataBaseConnection");
        }

        public async Task<List<ProductCategory>> GetAllProductsCategoryAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<ProductCategory>("SELECT * FROM tbProductCategory WITH (NOLOCK)");
                return response.ToList();
            }
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(string id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = $"SELECT * FROM tbProductCategory WHERE id = {id}";
                var response = await connection.QueryAsync<ProductCategory>(query);
                return response.FirstOrDefault();
            }
        }

    }
}
