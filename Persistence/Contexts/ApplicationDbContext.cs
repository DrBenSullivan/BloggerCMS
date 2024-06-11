using BloggerCMS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggerCMS.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogEntry>()
                .HasOne(blogEntry => blogEntry.Blog)
                .WithMany(blog => blog.BlogEntries)
                .HasForeignKey(blogEntry => blogEntry.BlogId) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blog>()
                .HasOne(blog => blog.Author)
                .WithMany(author => author.Blogs)
                .HasForeignKey(blog => blog.AuthorId) 
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
