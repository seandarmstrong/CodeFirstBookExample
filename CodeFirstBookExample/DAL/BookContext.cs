using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstBookExample.DAL
{
    public class BookContext : DbContext
    {
        public BookContext()
        {
                
        }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=LAPTOP-0FFESSLQ\\SQLEXPRESS;Initial Catalog=BookDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany<Author>(p => p.Authors)
                .WithOne(x => x.Publisher)
                .HasForeignKey(k => k.PublisherId);
            modelBuilder.Entity<Author>()
                .HasMany<Book>(B => B.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(k => k.AuthorId);
        }
    }
}
