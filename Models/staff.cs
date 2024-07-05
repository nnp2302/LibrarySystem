using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class staff:IdentityUser
    {
        public staff()
        {
            Loans = new HashSet<Loan>();
            Members = new HashSet<Member>();
        }
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Fname { get; set; } = null!;
        
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Pass { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
