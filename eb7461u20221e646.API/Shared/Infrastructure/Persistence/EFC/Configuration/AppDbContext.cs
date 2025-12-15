using eb7461u20221e646.API.Insurance.Infrastructure.Persistence.EFC.Configuration.Extensions;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using eb7461u20221e646.API.Sinister.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Add Bounded Context Imports 
        builder.ApplyInsuranceConfigurations();
        
        builder.ApplySinisterConfigurations();
        
        builder.UseSnakeCaseNamingConvention();
    }
    
}