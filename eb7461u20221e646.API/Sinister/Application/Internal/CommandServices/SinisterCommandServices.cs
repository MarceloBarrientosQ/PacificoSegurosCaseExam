using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Sinister.Domain.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Services;

namespace eb7461u20221e646.API.Sinister.Aplication.Internal.CommandServices;

public class SinisterCommandServices(ISinisterRepository sinisterRepository, UnitOfWork unitOfWork) : ISinisterCommandService
{
    public async Task<Domain.Model.Aggregate.Sinister> Handle(CreateSinisterCommand command)
    {
        var customerId = new CustomerId(command.CustomerId);
        var insuranceId = new InsuranceId(command.InsuranceId);
        
        var sinister = new Domain.Model.Aggregate.Sinister(
            customerId,
            insuranceId,
            command.SinisterType
        );
        
        await sinisterRepository.AddAsync(sinister);
        await unitOfWork.CompleteAsync();
        return sinister;
    }
}