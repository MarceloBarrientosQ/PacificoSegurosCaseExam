using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using eb7461u20221e646.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Domain.Model.Entities;
using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;
using eb7461u20221e646.API.Sinister.Domain.Repositories;
using eb7461u20221e646.API.Sinister.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace eb7461u20221e646.API.Sinister.Application.Internal.CommandServices;

public class SinisterCommandServices
    (ISinisterRepository sinisterRepository, UnitOfWork unitOfWork, AppDbContext context) : ISinisterCommandService
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
        
        var customer = await context
            .Set<Customer>()
            .FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer is null)
        {
            // Si el customer no existe, elegimos lanzar una excepción controlada.
            // Alternativamente, podríamos devolver null o un result con error según la convención del proyecto.
            throw new InvalidOperationException($"Customer with id {customerId.Id} not found.");
        }

        customer.IncreaseSinisters();
        
        await unitOfWork.CompleteAsync();
        return sinister;
    }
}