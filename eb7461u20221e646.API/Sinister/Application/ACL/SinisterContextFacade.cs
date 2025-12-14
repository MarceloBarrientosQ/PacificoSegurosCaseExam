using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Sinister.Domain.Services;
using eb7461u20221e646.API.Sinister.Interfaces.ACL;

namespace eb7461u20221e646.API.Sinister.Aplication.ACL;

public class SinisterContextFacade(ISinisterCommandService sinisterCommandService,
                                 ISinisterQueryService sinisterQueryService) : ISinisterContextFacade
{
    public async Task<int> CreateSinister(int customerId, int insuranceId, string sinisterType)
    {   
        var sinisterTypeToString = Enum.Parse<ESinisterType>(sinisterType);
        
        var command = new CreateSinisterCommand(customerId, insuranceId, sinisterTypeToString);
        
        var sinister = await sinisterCommandService.Handle(command);
        
        return sinister.SinisterId;
    }

    public async Task<int> GetSinisterCountByCustomer(int customerId)
    {
        return await sinisterQueryService.Handle(
            new GetSinisterCountByCustomerQuery(customerId)
        );
    }
    
}