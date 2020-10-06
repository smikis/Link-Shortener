namespace Api.Domain.DatabaseService
{
    public static class Queries
    {
        public static string CreateDatabase = 
            @"CREATE TABLE links (
            ID          INTEGER  PRIMARY KEY
            NOT NULL
            UNIQUE,
            url         VARCHAR  NOT NULL,
            shortUrl             NOT NULL,
            createdDate DATETIME
            );";

        public static string InsertLink =
            @"INSERT INTO Links (ID, Url, ShortUrl, CreatedDate)
                VALUES (@Id, @Url, @ShortUrl, date('now'));";

        public static string RecordsCount = "SELECT COUNT(*) FROM Links;";

        public static string GetFullLink =
    @"SELECT Url FROM Links WHERE Id = @Id;";
    }
}