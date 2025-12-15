 
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb7461u20221e646.API.Sinister.Aplication.Internal.QueryServices;
using eb7461u20221e646.API.Sinister.Application.ACL;
using eb7461u20221e646.API.Sinister.Application.Internal.CommandServices;
using eb7461u20221e646.API.Sinister.Domain.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Services;
using eb7461u20221e646.API.Sinister.Infrastructure.Persistence.EFC.Repositories;
using eb7461u20221e646.API.Sinister.Interfaces.ACL;

namespace eb7461u20221e646.API.Sinister.Infrastructure.Interfaces.ASP.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static void AddSinisterContextServices(this WebApplicationBuilder builder)
    {
        // Sinister Bounded Context
        builder.Services.AddScoped<ISinisterRepository, SinisterRepository>();
        builder.Services.AddScoped<ISinisterCommandService, SinisterCommandServices>();
        builder.Services.AddScoped<ISinisterQueryService, SinisterQueryService>();
        builder.Services.AddScoped<ISinisterContextFacade, SinisterContextFacade>();
        
        // UnitOfWork usando fábrica
        builder.Services.AddScoped(provider =>
        {
            var context = provider.GetRequiredService<AppDbContext>();
            return new UnitOfWork(context);
        });
    }
}