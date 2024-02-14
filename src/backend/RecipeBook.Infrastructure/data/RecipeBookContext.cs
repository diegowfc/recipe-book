using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.model;

namespace RecipeBook.Infrastructure.data;

public class RecipeBookContext : DbContext
{
    public RecipeBookContext(DbContextOptions<RecipeBookContext> options) : base(options) {}

    public DbSet<User> tab_user { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeBookContext).Assembly);
    }
}
