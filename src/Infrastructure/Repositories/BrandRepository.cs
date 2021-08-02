using NowWhat.Application.Interfaces.Repositories;
using NowWhat.Domain.Entities.Catalog;

namespace NowWhat.Infrastructure.Repositories
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