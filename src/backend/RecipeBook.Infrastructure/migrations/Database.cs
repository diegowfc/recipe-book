using Dapper;
using MySqlConnector;

namespace RecipeBook.Infrastructure.migrations;

public static class Database
{
    public static void CreateDatabase(string databaseConnection, string databaseName)
    {
        using var connection = new MySqlConnection(databaseConnection);

        var parameters = new DynamicParameters();
        parameters.Add("nome", databaseName);

        var databases = connection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parameters);

        if (!databases.Any())
        {
            connection.Execute($"CREATE DATABASE {databaseName} ");
        }
    }
}
