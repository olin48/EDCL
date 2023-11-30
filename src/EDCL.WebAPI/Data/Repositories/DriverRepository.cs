using Dapper;
using EDCL.WebAPI.Data.DTOs;
using EDCL.WebAPI.Data.Models;
using EDCL.WebAPI.Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EDCL.WebAPI.Data.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly IDbConnection _dbConnection;

        public DriverRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
        public async Task<IEnumerable<DriverInfoDto>> FindDriverInfoByNoHP(string nohp)
        {

            string spName = "SP_EDCL1_GetDriverInfo";

            // Parameter yang akan diteruskan ke stored procedure
            var parameters = new
            {
                no_hp = nohp
            };

            return await _dbConnection.QueryAsync<DriverInfoDto>(spName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
