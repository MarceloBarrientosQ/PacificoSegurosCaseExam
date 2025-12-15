using eb7461u20221e646.API.Shared.Domain.Repositories;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}