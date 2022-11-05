using GraphQLServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.MethodExtensions
{
    public static class Extensions
    {
        public static async Task ConfigurarMigraciones(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = services.GetRequiredService<BlogContext>();
                await context.Database.MigrateAsync();
                await BlogContextSeed.SeedAsync(context, loggerFactory);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Ocurrió un error durante la migración");
            }
        }
        
    }
}
