using api.DbContext;

namespace api.Extension
{
    public static class WebApplicationExtension
    {
        public static void MigrateDbContext(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ShortenLinkDbContext>();
            context.Database.EnsureCreated();
        }
    }
}