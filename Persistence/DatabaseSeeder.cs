using Microsoft.EntityFrameworkCore;
using BloggerCMS.Domain.Models;
using BloggerCMS.Persistence.Contexts;

namespace BloggerCMS
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // If Accounts table has entries, database already seeded, return.
                if (context.Accounts.Any())
                {
                    return;
                }

                var account = new Account { Username = "Prof. Author" };
                context.Accounts.Add(account);
                context.SaveChanges();

                var blog = new Blog
                {
                    Title = "My first blog",
                    Description = "A blog for testing purposes",
                    Author = account
                };
                context.Blogs.Add(blog);
                context.SaveChanges();

                var blogEntry = new BlogEntry
                {
                    Title = "My first blog entry",
                    Body = "Welcome to my very first blog entry!",
                    DatePosted = DateTime.Now,
                    Blog = blog
                };
                context.BlogEntries.Add(blogEntry);
                context.SaveChanges();
            }
        }
    }
}
