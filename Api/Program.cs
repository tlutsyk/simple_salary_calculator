using ApplicationServices.Features.Employees.GetById;
using DAL.Repositories;
using Domain.Calculator;
using Domain.Employee;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository, DependentRepositoryMock>();

// Todo: Add cache decorators if it is necessary;
builder.Services.AddScoped<IEmployeeQueryRepository, DependentRepositoryMock>();

builder.Services.AddSingleton<IPaycheckCalculator, PaycheckCalculator>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(
        typeof(GetEmployeeById).Assembly,
        typeof(DependentRepositoryMock).Assembly);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Benefit Cost Calculation Api",
        Description = "Api to support employee benefit cost calculations"
    });
});

var allowLocalhost = "allow localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowLocalhost,
        policy => { policy.WithOrigins("http://localhost:3000", "http://localhost"); });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowLocalhost);

app.UseAuthorization();

app.MapControllers();

app.Run();
