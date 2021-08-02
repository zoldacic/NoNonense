using NowWhat.Application.Specifications.Base;
using NowWhat.Domain.Entities.Catalog;

namespace NowWhat.Application.Specifications.Catalog
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
