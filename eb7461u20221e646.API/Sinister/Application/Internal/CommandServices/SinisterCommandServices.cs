using eb7461u20221e646.API.Insurance.Infrastructure.Interfaces.ACL;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Sinister.Domain.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Services;

namespace eb7461u20221e646.API.Sinister.Application.Internal.CommandServices;

public class SinisterCommandServices
    (ISinisterRepository sinisterRepository, UnitOfWork unitOfWork, IInsuranceContextFacade insuranceContextFacade) : ISinisterCommandService
{
    public async Task<Domain.Model.Aggregate.Sinister> Handle(CreateSinisterCommand command)
    {
        var insuranceExists =
            await insuranceContextFacade.InsuranceExists(command.InsuranceId);

        if (!insuranceExists)
            throw new Exception("Insurance does not exist");

        var sinister = new Domain.Model.Aggregate.Sinister(
            new CustomerId(command.CustomerId),
            new InsuranceId(command.InsuranceId),
            command.SinisterType
        );

        await sinisterRepository.AddAsync(sinister);
        await unitOfWork.CompleteAsync();

        return sinister;
    }
}