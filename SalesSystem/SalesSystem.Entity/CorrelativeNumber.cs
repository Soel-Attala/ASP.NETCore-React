using System;
using System.Collections.Generic;

namespace SalesSystem.Entity
{
    public partial class CorrelativeNumber
    {
        public int IdCorrelativeNumber { get; set; }
        public int? LastNumber { get; set; }
        public int? DigitCount { get; set; }
        public string? Management { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
