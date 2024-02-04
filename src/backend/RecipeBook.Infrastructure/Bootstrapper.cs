using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeBook.Domain.extension;
using System.Reflection;

namespace RecipeBook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        AddFluentMigrator(services, configurationManager);
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddMySql5()
            .WithGlobalConnectionString(configurationManager.GetFullConnection()).ScanIn(Assembly.Load("RecipeBook.Infrastructure")).For.All()
            );
    }
}
