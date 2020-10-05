using Api.Domain.DatabaseService.Models;

namespace Api.Domain.DatabaseService
{
    public interface IDatabaseService
    {
        int GetLinksCount();
        void WriteLinkInformation(ShortLink link);
    }
}