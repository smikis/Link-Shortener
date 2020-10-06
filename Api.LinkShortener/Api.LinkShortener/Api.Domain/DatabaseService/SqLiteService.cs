using System.IO;
using System.Threading.Tasks;
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

        public async Task WriteLinkInformationAsync(ShortLink link)
        {
            using (_connection)
            {
                await _connection.ExecuteAsync(Queries.InsertLink, link);

            }
        }

        public int GetLinksCount()
        {
            using (_connection)
            {
                return _connection.ExecuteScalar<int>(Queries.RecordsCount);

            }
        }

        public string GetFullUrl(long id)
        {
            using (_connection)
            {
                return _connection.ExecuteScalar<string>(Queries.GetFullLink, new { Id = id });

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