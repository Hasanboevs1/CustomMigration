using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CustomMigration.Models;

public class CreateUserOperation : MigrationOperation
{
    public string Name { get; set; }
    public string Password { get; set; }
}
