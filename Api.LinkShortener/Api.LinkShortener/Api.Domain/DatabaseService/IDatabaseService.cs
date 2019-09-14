using Api.Domain.DatabaseService.Models;

namespace Api.Domain.DatabaseService
{
    public interface IDatabaseService
    {
        void WriteLinkInformation(ShortLink link);
    }
}