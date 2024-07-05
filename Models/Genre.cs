using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int GenreId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
