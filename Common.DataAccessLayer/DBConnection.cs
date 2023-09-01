using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Common.DataAccessLayer
{
    public class DBConnection : IDBConnection
    {
        private readonly IConfiguration _configuration;
        public DBConnection(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public string GetConnection()
        {
            //var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST");
            //var database = Environment.GetEnvironmentVariable("DATABASE");
            //var user = Environment.GetEnvironmentVariable("SQLUSER");
            //var password = Environment.GetEnvironmentVariable("PASSWORD");


            //var connectionString = $"Server={hostname};Initial Catalog={database};User ID={user};Password={password};";
            var connectionString = _configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            return connectionString;
        }
    }
}
