using CustomMigration.Data;
using CustomMigration.Migrators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connection = builder.Configuration.GetConnectionString("customConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connection).ReplaceService<IMigrationsSqlGenerator, MyMigrationsSqlGenerator>();
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
