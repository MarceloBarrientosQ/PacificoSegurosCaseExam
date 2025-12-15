using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Interfaces.REST.Resources;

namespace eb7461u20221e646.API.Sinister.Interfaces.REST.Transform;

public static class SinisterResourceFromEntityAssembler
{
     public static SinisterResource ToResourceFromEntity(Domain.Model.Aggregate.Sinister sinister)
     {
          return new SinisterResource(
               sinister.SinisterId,
               sinister.CustomerId.Id,
               sinister.InsuranceId.Id,
               sinister.SinisterType.ToString(),
               sinister.DateAt
          );
     }
    
}