
using eb7461u20221e646.API.Insurance.Domain.Model.Aggregate;
using eb7461u20221e646.API.Insurance.Domain.Model.Commands;

public interface IInsuranceCommandService
{
    public Task<Insurance> Handle(CreateInsuranceCommand command);
}