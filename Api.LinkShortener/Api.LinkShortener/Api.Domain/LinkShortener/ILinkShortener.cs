namespace Api.Domain.LinkShortener
{
    public interface ILinkShortener
    {
        string ShortenLink(string url);
    }
}