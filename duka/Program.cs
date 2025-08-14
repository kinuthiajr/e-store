using duka.Services;
using Duka.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        npgsqlOptions.MigrationsHistoryTable(DatabaseConsts.MigrationHistoryTable, DatabaseConsts.Schema);
    }));


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Apply migrations and seed the database on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("Applying database migrations...");
    await dbContext.Database.MigrateAsync();

    logger.LogInformation("Attempting to seed the database...");
    await DatabaseSeedService.SeedAsync(dbContext);
    logger.LogInformation("Database seeding process completed.");
}

app.UseHttpsRedirection();





app.Run();
