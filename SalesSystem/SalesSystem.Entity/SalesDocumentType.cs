using System;
using System.Collections.Generic;

namespace SalesSystem.Entity
{
    public partial class SalesDocumentType
    {
        public SalesDocumentType()
        {
            Sales = new HashSet<Sale>();
        }

        public int IdSalesDocumentType { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
