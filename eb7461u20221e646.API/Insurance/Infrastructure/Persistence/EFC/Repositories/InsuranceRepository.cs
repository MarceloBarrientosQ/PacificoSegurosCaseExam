using eb7461u20221e646.API.Insurance.Domain.Model.Aggregate;
using eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;


public class InsuranceRepository(AppDbContext context) : BaseRepository<Insurance>(context), IInsuranceRepository
{
    public async Task<IEnumerable<Insurance>> FindByCategoryAsync(Category category)
    {
        return await Context.Set<Insurance>()
            .Where(i => i.Category.Value == category.Value)
            .ToListAsync();
    }
}