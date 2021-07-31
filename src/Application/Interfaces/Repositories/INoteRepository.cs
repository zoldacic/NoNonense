using System.Threading.Tasks;

namespace NoNonense.Application.Interfaces.Repositories
{
    public interface INoteRepository
    {
        Task<bool> IsTagUsed(int tagId);
    }
}