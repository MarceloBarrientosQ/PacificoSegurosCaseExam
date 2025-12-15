using eb7461u20221e646.API.Insurance.Aplication.Internal.QueryServices;
using eb7461u20221e646.API.Insurance.Application.ACL;
using eb7461u20221e646.API.Insurance.Application.Internal.CommandServices;
using eb7461u20221e646.API.Insurance.Infrastructure.Interfaces.ACL;

namespace eb7461u20221e646.API.Insurance.Infrastructure.Interfaces.ASP.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static void AddInsuranceContextServices(this WebApplicationBuilder builder)
    {
        // Insurance Bounded Context
        builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
        builder.Services.AddScoped<IInsuranceCommandService, InsuranceCommandService>();
        builder.Services.AddScoped<IInsuranceQueryService, InsuranceQueryService>();
        builder.Services.AddScoped<IInsuranceContextFacade, InsuranceContextFacade>();
    }
}