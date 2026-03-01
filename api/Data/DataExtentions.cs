using System;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public static class DataExtentions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
        dbContext.Database.Migrate();
    }

    public static void AddApplicationDb(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDBContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}
