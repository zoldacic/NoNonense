using System.Threading.Tasks;

namespace NowWhat.Application.Interfaces.Repositories
{
    public interface INoteRepository
    {
        Task<bool> IsTagUsed(int tagId);
    }
}