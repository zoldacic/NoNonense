using NoNonense.Domain.Contracts;

namespace NoNonense.Domain.Entities.Catalog
{
    public class Tag : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }
    }
}