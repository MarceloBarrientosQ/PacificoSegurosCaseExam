using eb7461u20221e646.API.Insurance.Domain.Model.Aggregate;
using eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Shared.Domain.Repositories;

public interface IInsuranceRepository : IBaseRepository<Insurance>
{
    Task<IEnumerable<Insurance>> FindByCategoryAsync(Category category);
}