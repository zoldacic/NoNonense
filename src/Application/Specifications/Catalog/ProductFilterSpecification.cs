using NoNonense.Application.Specifications.Base;
using NoNonense.Domain.Entities.Catalog;

namespace NoNonense.Application.Specifications.Catalog
{
    public class NoteFilterSpecification : HeroSpecification<Note>
    {
        public NoteFilterSpecification(string searchString)
        {
            Includes.Add(a => a.Tag);
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Barcode != null && (p.Name.Contains(searchString) || p.Description.Contains(searchString) || p.Barcode.Contains(searchString) || p.Tag.Name.Contains(searchString));
            }
            else
            {
                Criteria = p => p.Barcode != null;
            }
        }
    }
}