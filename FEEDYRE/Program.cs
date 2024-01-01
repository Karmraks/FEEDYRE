using System.Reflection;
using FEEDYRE.Core.Abstractions.Interfaces;
using FEEDYRE.Core.Data;
using FEEDYRE.Core.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(opt => 
    opt.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

Database.Migrate(app);

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
