using Data;
using Data.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using userapi;
using userapi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(oBuilder =>
    oBuilder.UseSqlServer("Server=localhost;Database=RPapi;User Id=tnt;Password=1;encrypt=false;"));

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddTransient<IProjectRepository, DeveloperRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

#endregion

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