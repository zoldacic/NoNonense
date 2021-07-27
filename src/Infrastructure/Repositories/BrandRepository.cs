using NoNonense.Application.Interfaces.Repositories;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand, int> _repository;

        public BrandRepository(IRepositoryAsync<Brand, int> repository)
        {
            _repository = repository;
        }
    }
}