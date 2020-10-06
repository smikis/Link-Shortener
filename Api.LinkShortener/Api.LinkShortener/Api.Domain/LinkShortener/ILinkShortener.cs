using System.Threading.Tasks;

namespace Api.Domain.LinkShortener
{
    public interface ILinkShortener
    {
        string GetFullUrl(string shortUrl);
        Task<string> ShortenLink(string url);
    }
}