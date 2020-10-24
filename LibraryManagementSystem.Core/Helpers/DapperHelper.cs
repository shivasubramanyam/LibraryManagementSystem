using Dapper;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Helpers
{
    public class DapperHelper : IDapper
    {
        private readonly string _connectionString;

        public DapperHelper(IConfiguration config)
        {
            _connectionString = config["Database:ConnectionString"];
        }

        public async Task<int> ExecuteAsync(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            int count;
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    count = await db.ExecuteAsync(sp, parameters, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return count;
        }

        public async Task<T> GetAsync<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = await db.QueryAsync<T>(sp, parameters, commandType: commandType);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<T>(sp, parameters, commandType: commandType);
        }

        public void Dispose()
        {
            
        }
    }
}