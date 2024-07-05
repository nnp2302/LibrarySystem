using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class Department
    {
        public Department()
        {
            staff = new HashSet<staff>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<staff> staff { get; set; }
    }
}
