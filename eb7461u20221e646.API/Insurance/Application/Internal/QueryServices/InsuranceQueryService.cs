using eb7461u20221e646.API.Insurance.Domain.Model.Queries;
using eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;

namespace eb7461u20221e646.API.Insurance.Aplication.Internal.QueryServices;

public class InsuranceQueryService
(IInsuranceRepository insuranceRepository) : IInsuranceQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregate.Insurance>> Handle(GetInsuranceByCategory query)
    {
        var category = new Category(query.Category);
        return await insuranceRepository.FindByCategoryAsync(category);
    }

    public async Task<Domain.Model.Aggregate.Insurance> Handle(GetInsuranceById query)
    {
        return await insuranceRepository.FindByIdAsync(query.Id);
    }
}