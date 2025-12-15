using eb7461u20221e646.API.Insurance.Domain.Model.Queries;
using eb7461u20221e646.API.Insurance.Infrastructure.Interfaces.ACL;

namespace eb7461u20221e646.API.Insurance.Application.ACL;

public class InsuranceContextFacade(IInsuranceQueryService insuranceQueryService) : IInsuranceContextFacade
{
    public async Task<bool> InsuranceExists(int insuranceId)
    {
        var insurance = await insuranceQueryService
            .Handle(new GetInsuranceById(insuranceId));

        return insurance != null;
    }
}