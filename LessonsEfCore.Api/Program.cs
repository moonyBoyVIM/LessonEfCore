using LessonsEfCore.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseNpgsql(config.GetConnectionString("LessonDbConnection"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
