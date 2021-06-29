using System;
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
    public class OrderService
    {
        private readonly string _connectionString;
        public OrderService(IConfiguration configuration)
        {
            _connectionString = configuration
            .GetConnectionString("DataBaseConnection");
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Order>("SELECT * FROM Orders WITH (NOLOCK)");
                return response.ToList();
            }   
        }
    
        public async Task<Order> GetOrderByIdAsync(string id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var response = await connection
                .QueryAsync<Order>("SELECT * FROM Orders WITH (NOLOCK) WHERE Id = @Id", new {Id = id});
                return response.FirstOrDefault();
            }
        }
    
        public async Task CreateOrder(object order, List<object> products)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("CreateOrder", order, commandType: CommandType.StoredProcedure);
                await connection.ExecuteAsync("InsertProductsOrder", products, commandType: CommandType.StoredProcedure);
            }
        }
    
        //public async Task UpdateOrder(string id) {}

        //public async Task DeleteOrder(string id) {}
    }
}