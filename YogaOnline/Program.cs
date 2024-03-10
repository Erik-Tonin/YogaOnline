using Application.Contracts;
using Application.Implementations;
using Application.Mappings;
using Microsoft.EntityFrameworkCore;
using YogaOnline.Domain.Contracts.IRepositories;
using YogaOnline.Infra.Context;
using YogaOnline.Infra.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITeacherApplicationService, TeacherApplicationService>();

//Repository
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUserRepository, UserRepositorie>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
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

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
