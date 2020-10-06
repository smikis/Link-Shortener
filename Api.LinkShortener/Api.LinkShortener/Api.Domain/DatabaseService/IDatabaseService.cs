using Api.Domain.DatabaseService.Models;
using System.Threading.Tasks;

namespace Api.Domain.DatabaseService
{
    public interface IDatabaseService
    {
        string GetFullUrl(long id);
        int GetLinksCount();
        Task WriteLinkInformationAsync(ShortLink link);
    }
}