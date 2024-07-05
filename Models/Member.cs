using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class Member
    {
        public Member()
        {
            Loans = new HashSet<Loan>();
        }

        public int MemberId { get; set; }
        public string Fname { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddressFull { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? RegisteredByStaffId { get; set; }

        public virtual staff? RegisteredByStaff { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
