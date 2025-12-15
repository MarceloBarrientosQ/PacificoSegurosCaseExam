using eb7461u20221e646.API.Insurance.Interfaces.REST.Resources;

namespace eb7461u20221e646.API.Insurance.Interfaces.REST.Transform;

public static class InsuranceResourceFromEntityAssembler
{
    public static InsuranceResource ToResourceFromEntity(Domain.Model.Aggregate.Insurance insurance)
    {
        return new InsuranceResource
        (
            insurance.InsuranceId,
            insurance.Name,
            insurance.Category.Value,
            insurance.Subcategory.Value,
            insurance.RegisteredDate
        );
    }
}