using CustomMigration.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace CustomMigration.Extensions;

public static class MigrationBuilderExtensions
{
    public static OperationBuilder<SqlOperation> CreateUser(
        this MigrationBuilder builder,
        string name,
        string password)
    {
        var operation = new CreateUserOperation { Name = name, Password = password };

        var operations = new List<MigrationOperation>(builder.Operations);

        operations.Add(operation);

        switch (builder.ActiveProvider)
        {
            case "Npgsql.EntityFrameworkCore.PostgreSQL":
                return builder.Sql($"CREATE USER {name} WITH PASSWORD '{password}';");

            case "Microsoft.EntityFrameworkCore.SqlServer":
                return builder.Sql($"CREATE USER {name} WITH PASSWORD '{password}';");

            default:
                throw new Exception("Unexpected Provider..."); // Faqat SqlServer yoki Postgres 
        }
    }
}
