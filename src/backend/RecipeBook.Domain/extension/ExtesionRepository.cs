using Microsoft.Extensions.Configuration;

namespace RecipeBook.Domain.extension;

public static class ExtesionRepository
{
    public static string GetConnection(this IConfiguration configurationManager)
    {
        var connection = configurationManager.GetConnectionString("Connection");

        return connection;
    }

    public static string GetDatabaseName(this IConfiguration configurationManager)
    {
        var databaseName = configurationManager.GetConnectionString("DatabaseName");

        return databaseName;
    }

    public static string GetFullConnection(this IConfiguration configurationManager)
    {
        var databaseName = configurationManager.GetDatabaseName();
        var connection = configurationManager.GetConnection();

        return $"{connection}Database={databaseName}";
    }
}
