using FluentMigrator;

namespace RecipeBook.Infrastructure.migrations.Versions;

[Migration((long)VersionNumbers.CreateUserTable, "Create user table")]
public class Version2024020401User : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var table = BaseVersion.InsertStandardColumns(Create.Table("tab_user"));

        table
            .WithColumn("username").AsString(255).NotNullable()
            .WithColumn("password").AsString(2000).NotNullable()
            .WithColumn("email").AsString(100).NotNullable()
            .WithColumn("phone").AsString(14).NotNullable();
             
    }
}
