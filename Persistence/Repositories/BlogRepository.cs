using System.Text.Json;
using BloggerCMS.Domain.Models;
using BloggerCMS.Domain.Repositories.Interfaces;

namespace BloggerCMS.Persistence.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly static string _testSeedJSON = @"
        [
            {
                ""Id"": 0,
                ""Author"": ""Prof. Author"",
                ""DatePosted"": ""2024-06-07T00:00:00"",
                ""Title"": ""My first"",
                ""Body"": ""Welcome to my blog.""
            },
            {
                ""Id"": 1,
                ""Author"": ""Prof. Author"",
                ""DatePosted"": ""2024-06-07T12:00:00"",
                ""Title"": ""My second Post"",
                ""Body"": ""Requires navigation between posts.""
            }
        ]";

		public static int GetCount() 
        {
            var jsonEntries = JsonSerializer.Deserialize<IEnumerable<BlogEntry>>(_testSeedJSON);
            return jsonEntries?.Count() ?? 0;
        }

		public BlogEntry GetEntry(int id)
        {
            var jsonEntries = JsonSerializer.Deserialize<IEnumerable<BlogEntry>>(_testSeedJSON)!;
            var entry = jsonEntries?.FirstOrDefault(e => e.Id == id);

            if (entry != null)
            {
                return entry;
            }

            throw new KeyNotFoundException($"Blog entry with ID {id} not found.");
        }
    }
}
