using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class Penalty
    {
        public int PenaltyId { get; set; }
        public int? LoanId { get; set; }
        public string? PenaltyType { get; set; }
        public decimal? PenaltyAmount { get; set; }
        public DateTime? PenaltyDate { get; set; }

        public virtual Loan? Loan { get; set; }
    }
}
