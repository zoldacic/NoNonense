using NowWhat.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowWhat.Domain.Entities.Catalog
{
    public class Note : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }

        [Column(TypeName = "text")]
        public string ImageDataURL { get; set; }

        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}