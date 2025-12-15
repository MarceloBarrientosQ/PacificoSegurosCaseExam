using eb7461u20221e646.API.Insurance.Domain.Model.Commands;
using eb7461u20221e646.API.Insurance.Interfaces.REST.Resources;

namespace eb7461u20221e646.API.Insurance.Interfaces.REST.Transform;

public static class CreateInsuranceCommandFromResourceAssembler
{
    public static CreateInsuranceCommand ToCommandFromResource(CreateInsuranceResource resource)
    {
        return new CreateInsuranceCommand(resource.Name, resource.Category, resource.Subcategory);
    }
}