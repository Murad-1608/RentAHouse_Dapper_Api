using Microsoft.Data.SqlClient;
using System.Data;

namespace RentAHouse_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration configuration;

        private readonly string connectionString;
        public Context(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
