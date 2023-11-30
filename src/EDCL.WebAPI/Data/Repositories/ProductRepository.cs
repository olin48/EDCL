using Dapper;
using EDCL.WebAPI.Data.Models;
using EDCL.WebAPI.Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EDCL.WebAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }


        public async Task<IEnumerable<Products>> GetProducts()
        {
            var query = "SELECT * FROM Products";
            query = "SP_GET_PRODUCTS";
            return await _dbConnection.QueryAsync<Products>(query, commandType: CommandType.StoredProcedure);
        }
    }
}
