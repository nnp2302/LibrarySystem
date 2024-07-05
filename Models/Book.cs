using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public partial class Book
    {
        public Book()
        {
            Loans = new HashSet<Loan>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        public int? PublisherId { get; set; }
        public int? PublishedYear { get; set; }
        public string? Isbn { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
