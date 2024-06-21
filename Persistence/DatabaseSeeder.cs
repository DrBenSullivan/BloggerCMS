using Microsoft.EntityFrameworkCore;
using BloggerCMS.Domain.Models;
using BloggerCMS.Persistence.Contexts;
using System.Reflection;

namespace BloggerCMS
{
    public static class DatabaseSeeder
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
			using var context = new ApplicationDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
			// If Accounts table has entries, database already seeded, return.
			if (context.Accounts.Any())
			{
				return;
			}

			var account = new Account("Prof. Author");
			context.Accounts.Add(account);
			context.SaveChanges();

			var blog = new Blog();
			blog.Author = account;
			blog.Title = "My first blog.";
			blog.Description = "A blog for things.";
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
