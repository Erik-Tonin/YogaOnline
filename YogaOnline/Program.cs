using Application.Contracts;
using Application.Implementations;
using Microsoft.EntityFrameworkCore;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Infra.Context;
using YogaOnline.Infra.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

//Repository
builder.Services.AddScoped<IUserRepository, UserRepositorie>();
builder.Services.AddDbContext<MicroServiceContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));


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
