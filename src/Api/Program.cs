using Application.Repositories;
using Application.Security;
using Application.UseCases.PersonalAccounts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Security;
using AccessCore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<AccessCoreDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPersonalAccountRepository, PersonalAccountRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<RegisterPersonalAccountUseCase>();

// Add services to the container.

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
