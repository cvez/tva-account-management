using Application.Interfaces;
using Application.Services;
using Application.MappingProfiles;
using Application.Validators;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TvaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(PersonProfile), typeof(AccountProfile), typeof(TransactionProfile));

// Add FluentValidation
builder.Services.AddMvc().AddFluentValidation(fv =>
    fv.RegisterValidatorsFromAssemblyContaining<PersonValidator>());

// Add custom services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();