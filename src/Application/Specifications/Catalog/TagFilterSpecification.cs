using NoNonense.Application.Specifications.Base;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Application.Specifications.Catalog
{
    public class TagFilterSpecification : HeroSpecification<Tag>
    {
        public TagFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Name.Contains(searchString) || p.Description.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}
