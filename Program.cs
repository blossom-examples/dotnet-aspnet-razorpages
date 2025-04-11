using Microsoft.EntityFrameworkCore;
using DemoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Parse DATABASE_URL into connection string
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
var connectionString = databaseUrl != null
    ? ParseDatabaseUrl(databaseUrl)
    : "Host=localhost;Database=example_dotnet_razorpages_dev;Username=postgres;Password=postgres";

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await DbSeeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Handle database commands
if (args.Length > 0 && args[0] == "db-update")
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    Environment.Exit(0);
}

// Ensure database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

static string ParseDatabaseUrl(string databaseUrl)
{
    // Remove the "postgres://" prefix
    var url = databaseUrl.Replace("postgres://", "");

    // Split into user:pass@host:port/dbname
    var parts = url.Split('@');
    var credentials = parts[0].Split(':');
    var hostParts = parts[1].Split('/');
    var hostPort = hostParts[0].Split(':');

    var username = credentials[0];
    var password = credentials.Length > 1 ? credentials[1] : "";
    var host = hostPort[0];
    var port = hostPort.Length > 1 ? hostPort[1] : "5432";
    var database = hostParts[1];

    return $"Host={host};Port={port};Database={database};Username={username};Password={password}";
}