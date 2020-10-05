using Api.Domain.DatabaseService;
using Api.Domain.DatabaseService.Models;
using Api.Domain.UrlHasher;
using System;

namespace Api.Domain.LinkShortener
{
    public class LinkShortenerService : ILinkShortener
    {
        private readonly IDatabaseService _database;
        private readonly IUrlBaseEncoder _encoder;
        public LinkShortenerService(IDatabaseService database, IUrlBaseEncoder encoder)
        {
            _database = database;
            _encoder = encoder;
        }

        public string ShortenLink(string url)
        {
            var linksCount = _database.GetLinksCount();
            var id = linksCount + 1;
            var encodedCount = _encoder.EncodeUrl(linksCount + 1);
            var shorUrl = new ShortLink
            {
                Id = id,
                Url = url,
                ShortUrl = encodedCount,
                CreatedDate = DateTime.UtcNow
            };

            _database.WriteLinkInformation(shorUrl);

            return encodedCount;
        }
    }
}