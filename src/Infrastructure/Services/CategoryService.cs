using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Infrastructure.Services
{
    public class CategoryService
    {
        private readonly string _connectionString;
        public CategoryService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DataBaseConnection");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Category>("SELECT * FROM Categories WITH (NOLOCK)");
                return response.ToList();
            }
        }
    }
}