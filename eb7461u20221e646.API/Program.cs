using eb7461u20221e646.API.Insurance.Infrastructure.Interfaces.ASP.Configuration;
using eb7461u20221e646.API.Shared.Infrastructure.Documentation.OpenApi.Configuration.Extensions;
using eb7461u20221e646.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using eb7461u20221e646.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using eb7461u20221e646.API.Shared.Infrastructure.Mediator.Cortex.Configuration.Extensions;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7461u20221e646.API.Sinister.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Add Open Api Configuration
builder.AddOpenApiDocumentation();

// Add context-specific services
builder.AddSharedContextServices();
builder.AddInsuranceContextServices();
builder.AddSinisterContextServices();

// Mediator Configuration
builder.AddCortexConfigurationServices();


var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();