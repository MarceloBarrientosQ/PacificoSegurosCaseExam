using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Sinister.Interfaces.REST.Resources;

namespace eb7461u20221e646.API.Sinister.Interfaces.REST.Transform;

public static class CreateSinisterCommandFromResourceAssembler
{
    public static CreateSinisterCommand toCommandFromResource(CreateSinisterResource resource)
    {
        var sinisterType = Enum.Parse<ESinisterType>(resource.SinisterType, true);
        
        return new CreateSinisterCommand(resource.CustomerId, resource.InsuranceId, sinisterType);
    }
}