using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace autos_api.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateAsyncScope();

            using MarcaAutoDbContext dbContext = scope.ServiceProvider.GetRequiredService<MarcaAutoDbContext>();

            dbContext.Database.Migrate();
        }
    }
}