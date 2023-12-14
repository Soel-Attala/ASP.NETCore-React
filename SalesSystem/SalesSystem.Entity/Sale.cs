using System;
using System.Collections.Generic;

namespace SalesSystem.Entity
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int IdSale { get; set; }
        public string? SaleNumber { get; set; }
        public int? IdSalesDocumentType { get; set; }
        public int? IdUser { get; set; }
        public string? CustomerDocument { get; set; }
        public string? CustomerName { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual SalesDocumentType? IdSalesDocumentTypeNavigation { get; set; }
        public virtual UserData? IdUserNavigation { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
