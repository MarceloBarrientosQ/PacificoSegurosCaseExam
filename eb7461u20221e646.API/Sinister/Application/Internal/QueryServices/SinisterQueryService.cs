using eb7461u20221e646.API.Sinister.Domain.Model.Queries;
using eb7461u20221e646.API.Sinister.Domain.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Services;

namespace eb7461u20221e646.API.Sinister.Aplication.Internal.QueryServices;

public class SinisterQueryService
(ISinisterRepository sinisterRepository) : ISinisterQueryService
{
    public async Task<Domain.Model.Aggregate.Sinister> Handle(GetSinisterById query)
    {
        return await  sinisterRepository.FindByIdAsync(query.SinisterId);
    }
}