using Application.Mappings;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add SQLite DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(ObjectMapper)); // Ensure to include your AutoMapper profile class

// Generic Repository Pattern
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Specification Pattern
builder.Services.AddScoped(typeof(ISpecification<>), typeof(Specification<>));

// Generic Unit of Work Pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI and Swagger JSON endpoint in development mode
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map controllers for handling requests
app.MapControllers();

// Start the application
await app.RunAsync();