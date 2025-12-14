using eb7461u20221e646.API.Sinister.Domain.Model.Commands;
using eb7461u20221e646.API.Sinister.Domain.Model.Queries;

namespace eb7461u20221e646.API.Sinister.Domain.Services;

public interface ISinisterCommandServices
{
    public Task<Model.Aggregate.Sinister> Handle(CreateSinisterCommand command);
}