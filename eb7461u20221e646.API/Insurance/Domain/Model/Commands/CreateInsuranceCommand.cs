using eb7461u20221e646.API.Insurance.Domain.Model.ValueObjects;

namespace eb7461u20221e646.API.Insurance.Domain.Model.Commands;

public record CreateInsuranceCommand(string Name, string Category, string Subcategory);