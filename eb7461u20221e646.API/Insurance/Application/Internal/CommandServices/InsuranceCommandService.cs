 

using eb7461u20221e646.API.Insurance.Domain.Model.Commands;
using eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Shared.Domain.Repositories;

namespace eb7461u20221e646.API.Insurance.Application.Internal.CommandServices;

public class InsuranceCommandService(
    IInsuranceRepository insuranceRepository,
    IUnitOfWork unitOfWork
) : IInsuranceCommandService
{
    public async Task<Domain.Model.Aggregate.Insurance> Handle(CreateInsuranceCommand command)
    {
        var category = new Category(command.Category);
        var subcategory = new Subcategory(category, command.Subcategory);
        
        var insurance = new Domain.Model.Aggregate.Insurance(
            command.Name,
            category,
            subcategory
        );
        
        await insuranceRepository.AddAsync(insurance);
        await unitOfWork.CompleteAsync();
        
        return insurance;
    }
}