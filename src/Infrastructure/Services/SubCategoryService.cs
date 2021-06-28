using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class SubCategoryService
    {
       private readonly string _connectionString;
        public SubCategoryService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DataBaseConnection");
        }

        public async Task<List<SubCategory>> GetCategoriesAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<SubCategory>("SELECT * FROM SubCategories WITH (NOLOCK)");
                return response.ToList();
            }
        }

        public async Task<List<SubCategory>> GetByCategoryIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<SubCategory>("SELECT * FROM SubCategories WITH (NOLOCK) WHERE CategoryId = @id", new { id });
                return response.ToList();
            }
        }
    }
}