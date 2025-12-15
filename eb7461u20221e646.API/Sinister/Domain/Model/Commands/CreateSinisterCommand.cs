using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;

namespace eb7461u20221e646.API.Sinister.Domain.Model.Commands;

public record CreateSinisterCommand(int CustomerId, int InsuranceId, ESinisterType SinisterType) ;