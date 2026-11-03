using Microsoft.EntityFrameworkCore;
using Users.APP.Domain; // UsersDb'nin gerçek namespace'i neyse onu yaz

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the application's DbContext dependency injection
// by sending UsersDb instances to the injected service class
// constructors' DbContext or UsersDb parameter, using SQLite
// with the connection string from appsettings.json.
builder.Services.AddDbContext<DbContext, UsersDb>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString(nameof(UsersDb))));
// nameof(UsersDb) = "UsersDb" which is the class name.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();