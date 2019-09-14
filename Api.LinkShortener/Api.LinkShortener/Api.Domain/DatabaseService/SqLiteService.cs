using System.IO;
using Api.Domain.DatabaseService.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Api.Domain.DatabaseService
{
    public class SqLiteService : IDatabaseService
    {
        private SqliteConnection _connection;
        private readonly IConfiguration _configuration;
        public SqLiteService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            _connection = new SqliteConnection(connectionString);
            
            var database = _configuration.GetSection("AppSettings")["DatabaseName"];
            if (!File.Exists(database))
            {
                CreateDatabase();
            }
        }
        
        public void WriteLinkInformation(ShortLink link)
        {
            using (_connection)
            {
                _connection.ExecuteAsync(Queries.InsertLink, link);
                
            }
        }

        private void CreateDatabase()
        {
            using (_connection)
            {
                _connection.Execute(Queries.CreateDatabase);
            }
        }
    }
}