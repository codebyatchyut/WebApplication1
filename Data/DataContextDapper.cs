using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Data
{
    public class DataContextDapper
    {
        private readonly IConfiguration _config;

        public DataContextDapper(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sqlCommand)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return connection.Query<T>(sqlCommand);
        }

        public T LoadSingleData<T>(string sqlCommand)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return connection.QuerySingle<T>(sqlCommand);
        }

        public bool ExecuteCommand(string sqlCommand)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sqlCommand) > 0;
        }

        public int ExecuteCommandWithCount(string sqlCommand)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sqlCommand);
        }
    }
}
