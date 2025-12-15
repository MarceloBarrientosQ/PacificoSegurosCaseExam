namespace eb7461u20221e646.API.Insurance.Infrastructure.Interfaces.ACL;

public interface IInsuranceContextFacade
{
    Task<bool> InsuranceExists(int insuranceId);
}