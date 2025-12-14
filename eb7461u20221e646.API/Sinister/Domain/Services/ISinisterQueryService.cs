using eb7461u20221e646.API.Sinister.Domain.Model.Queries;

namespace eb7461u20221e646.API.Sinister.Domain.Services;

public interface ISinisterQueryServices
{
    public Task<Model.Aggregate.Sinister> Handle(GetSinisterById query);
}