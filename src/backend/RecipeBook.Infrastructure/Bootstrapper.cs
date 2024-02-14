using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Domain.extension;
using RecipeBook.Domain.repository;
using RecipeBook.Infrastructure.data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        AddFluentMigrator(services, configurationManager);

        AddContext(services, configurationManager);
        AddUnitOfWork(services);
        AddRepositories(services);
    }

    private static void AddContext(IServiceCollection services, IConfigurationManager configurationManager)
    {
        var versionServer = new MySqlServerVersion(new Version(8, 0, 36));
        var connectionString = configurationManager.GetFullConnection();

        services.AddDbContext<RecipeBookContext>(DbContextOptions => {
            DbContextOptions.UseMySql(connectionString, versionServer);
        });
    }

    private static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserReadRepository, UserRepository>()
            .AddScoped<IUserWriteRepository, UserRepository>();
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddMySql5()
            .WithGlobalConnectionString(configurationManager.GetFullConnection()).ScanIn(Assembly.Load("RecipeBook.Infrastructure")).For.All()
            );
    }
}
