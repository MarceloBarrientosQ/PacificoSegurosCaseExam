using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Repositories;

namespace eb7461u20221e646.API.Sinister.Infrastructure.Persistence.EFC.Repositories;

public class SinisterRepository(AppDbContext context) 
    : BaseRepository<Domain.Model.Aggregate.Sinister>(context), ISinisterRepository
{
    
}