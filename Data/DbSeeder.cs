using Microsoft.EntityFrameworkCore;
using DemoApp.Models;

namespace DemoApp.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Ensure database is created and migrations are applied
        await context.Database.MigrateAsync();

        // Check if we already have data
        if (await context.Todos.AnyAsync())
        {
            return;
        }

        // Add sample todos
        var todos = new[]
        {
            new Todo
            {
                Title = "Become a Coffee Connoisseur",
                Description = "Sample every coffee shop in town and rate them on a scale of 'meh' to 'life-changing'",
                IsComplete = false,
                CreatedAt = DateTime.UtcNow
            },
            new Todo
            {
                Title = "Invent a New Dance Move",
                Description = "Create a dance so unique it goes viral. Name it after yourself.",
                IsComplete = false,
                CreatedAt = DateTime.UtcNow
            },
            new Todo
            {
                Title = "Master the Art of Dad Jokes",
                Description = "Collect and perfect dad jokes until they're so bad they're good again",
                IsComplete = true,
                CreatedAt = DateTime.UtcNow
            },
            new Todo
            {
                Title = "Create a Time Machine",
                Description = "Build a device that lets you travel back to when you had more free time",
                IsComplete = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        await context.Todos.AddRangeAsync(todos);
        await context.SaveChangesAsync();
    }
}