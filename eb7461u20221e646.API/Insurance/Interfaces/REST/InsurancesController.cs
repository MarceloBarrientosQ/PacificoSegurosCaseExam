using System.Net.Mime;
using eb7461u20221e646.API.Insurance.Domain.Model.Queries;
using eb7461u20221e646.API.Insurance.Interfaces.REST.Resources;
using eb7461u20221e646.API.Insurance.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb7461u20221e646.API.Insurance.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Insurances endpoints")]
public class InsurancesController(IInsuranceQueryService insuranceQueryService,
    IInsuranceCommandService insuranceCommandService) : ControllerBase
{
    [HttpGet("category/{category}")]
    [SwaggerOperation(
        Summary = "Get insurances by category",
        Description = "Get all insurances that belong to the specified category",
        OperationId = "GetInsurancesByCategory")]
    [SwaggerResponse(
        StatusCodes.Status200OK,
        "Insurances found",
        typeof(IEnumerable<InsuranceResource>))]
    [SwaggerResponse(
        StatusCodes.Status404NotFound,
        "No insurances found for the given category")]
    public async Task<IActionResult> GetInsurancesByCategory([FromRoute] string category)
    {
        var insurances = await insuranceQueryService
            .Handle(new GetInsuranceByCategory(category));
        
        if (!insurances.Any())
            return NotFound();

        var insurancesResources =
            insurances
                .Select(InsuranceResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(insurancesResources);
    }
    
    [HttpGet("{insuranceId:int}")]
    [SwaggerOperation(
        Summary = "Get insurance by id",
        Description = "Get insurance by id",
        OperationId = "GetInsuranceById")]
    [SwaggerResponse(
        StatusCodes.Status200OK,
        "Insurances found",
        typeof(InsuranceResource))]
    [SwaggerResponse(
        StatusCodes.Status404NotFound,
        "No insurances found for the given category")]
    public async Task<IActionResult> GetInsuranceById([FromRoute] int insuranceId)
    {
        var insurance = await insuranceQueryService
            .Handle(new GetInsuranceById(insuranceId));
        
        if( insurance is null)
            return NotFound();
        
        var insuranceResource = InsuranceResourceFromEntityAssembler.ToResourceFromEntity(insurance);
        
        return Ok(insuranceResource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new insurance",
        Description = "Create a new insurance with the provided details",
        OperationId = "CreateInsurance")]
    [SwaggerResponse(
        StatusCodes.Status201Created,
        "Insurance created successfully",
        typeof(InsuranceResource))]
    [SwaggerResponse(
        StatusCodes.Status400BadRequest,
        "Invalid input data")]
    public async Task<IActionResult> CreateInsurance([FromBody] CreateInsuranceResource resource)
    {
        var command = CreateInsuranceCommandFromResourceAssembler
            .ToCommandFromResource(resource);
        
        var insurance = await insuranceCommandService
            .Handle(command);
        
        var insuranceResource = 
            InsuranceResourceFromEntityAssembler
                .ToResourceFromEntity(insurance);
        
        return CreatedAtAction(
            nameof(GetInsuranceById), new { insuranceId = insurance.InsuranceId }, insuranceResource);
    }
}