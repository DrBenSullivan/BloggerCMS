using BloggerCMS;
using BloggerCMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

var host = CreateHostBuilder(args).Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    // Seed Db if first time application initialised.
    SeedData.Initialize(services);
}

host.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
