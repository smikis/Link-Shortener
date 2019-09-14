namespace Api.Domain.UrlHasher
{
    public interface IUrlBaseEncoder
    {
        string EncodeUrl(long seed);
        long DecodeUrl(string number);
    }
}