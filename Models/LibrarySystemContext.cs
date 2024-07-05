using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibrarySystem.Models
{
    public partial class LibrarySystemContext : DbContext
    {
        public LibrarySystemContext()
        {
        }

        public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Penalty> Penalties { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibrarySystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__AuthorID__4222D4EF");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Books__GenreID__4316F928");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__Books__Publisher__440B1D61");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.LoanDate).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Loans__BookID__49C3F6B7");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Loans__MemberID__4AB81AF0");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Loans__StaffID__4BAC3F29");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .HasColumnName("FName");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.RegisteredByStaffId).HasColumnName("RegisteredByStaffID");

                entity.HasOne(d => d.RegisteredByStaff)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RegisteredByStaffId)
                    .HasConstraintName("FK__Members__Registe__46E78A0C");
            });

            modelBuilder.Entity<Penalty>(entity =>
            {
                entity.Property(e => e.PenaltyId).HasColumnName("PenaltyID");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.PenaltyAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PenaltyDate).HasColumnType("date");

                entity.Property(e => e.PenaltyType).HasMaxLength(50);

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Penalties)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK__Penalties__LoanI__4E88ABD4");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .HasColumnName("FName");

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Staff__Departmen__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
