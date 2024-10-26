using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesBooks.Models;

namespace RazorPagesBooks.Data
{
    public class RazorPagesBooksContext : DbContext
    {
        public RazorPagesBooksContext (DbContextOptions<RazorPagesBooksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().Property(b => b.CoverURL).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.Summary).HasMaxLength(250);
        }

        public DbSet<RazorPagesBooks.Models.Book> Book { get; set; } = default!;
    }
}
