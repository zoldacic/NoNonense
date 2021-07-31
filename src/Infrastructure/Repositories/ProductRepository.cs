using NoNonense.Application.Interfaces.Repositories;
using NoNonense.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NoNonense.Infrastructure.Repositories
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