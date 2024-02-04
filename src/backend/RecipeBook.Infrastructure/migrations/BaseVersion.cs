using FluentMigrator.Builders.Create.Table;

namespace RecipeBook.Infrastructure.migrations;

/// <summary>
/// Method for the creation of the starndad fields for every table in our database
/// </summary>
public static class BaseVersion
{
    public static ICreateTableColumnOptionOrWithColumnSyntax InsertStandardColumns(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
    {
        return table.WithColumn("id").AsInt64().PrimaryKey().Identity()
             .WithColumn("register_date").AsDateTime().NotNullable();
    }
}
