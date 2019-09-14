using Api.Domain.DatabaseService;
using Api.Domain.UrlHasher;

namespace Api.Domain.LinkShortener
{
    public class LinkShortener
    {
        private readonly IDatabaseService database;
        private readonly IUrlBaseEncoder encoder;
        public LinkShortener(IDatabaseService database, IUrlBaseEncoder encoder)
        {
            
        }
        
        public string ShortenLink(string url)
        {
            return null;
        }
    }
}