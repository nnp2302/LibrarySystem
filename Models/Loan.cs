using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class Loan
    {
        public Loan()
        {
            Penalties = new HashSet<Penalty>();
        }

        public int LoanId { get; set; }
        public int? BookId { get; set; }
        public int? MemberId { get; set; }
        public int? StaffId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime DueDate { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Member? Member { get; set; }
        public virtual staff? Staff { get; set; }
        public virtual ICollection<Penalty> Penalties { get; set; }
    }
}
