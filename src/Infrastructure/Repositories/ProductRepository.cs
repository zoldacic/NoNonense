using NowWhat.Application.Interfaces.Repositories;
using NowWhat.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NowWhat.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IRepositoryAsync<Note, int> _repository;

        public NoteRepository(IRepositoryAsync<Note, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsTagUsed(int tagId)
        {
            return await _repository.Entities.AnyAsync(b => b.TagId == tagId);
        }
    }
}