using NoNonense.Application.Interfaces.Repositories;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IRepositoryAsync<Tag, int> _repository;

        public TagRepository(IRepositoryAsync<Tag, int> repository)
        {
            _repository = repository;
        }
    }
}