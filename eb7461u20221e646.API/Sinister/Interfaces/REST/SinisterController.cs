using System.Net.Mime;
using eb7461u20221e646.API.Sinister.Domain.Model.Queries;
using eb7461u20221e646.API.Sinister.Domain.Services;
using eb7461u20221e646.API.Sinister.Interfaces.REST.Resources;
using eb7461u20221e646.API.Sinister.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace eb7461u20221e646.API.Sinister.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Sinisters endpoints")]
public class SinisterController(ISinisterQueryService sinisterQueryService, 
    ISinisterCommandService sinisterCommandService) : ControllerBase
{
    [HttpGet("{insuranceId:int}")]
    [SwaggerOperation(
        Summary = "Get Sinister by InsuranceId",
        Description = "Get Sinister by InsuranceId",
        OperationId = "GetSinisterByInsuranceId"
    )]
    [SwaggerResponse(
        StatusCodes.Status200OK,
        "Sinister found",
        typeof(Domain.Model.Aggregate.Sinister)
    )]
    [SwaggerResponse(
        StatusCodes.Status404NotFound,
        "No sinister found for the given id")]
    public async Task<IActionResult> GetByInsuranceId([FromRoute] int sinisterId)
    {
        var sinister = await sinisterQueryService
            .Handle(new GetSinisterById(sinisterId));
        
        if (sinister == null)
        {
            return NotFound();
        }

        var sinisterResource = SinisterResourceFromEntityAssembler.ToResourceFromEntity(sinister);
        return Ok(sinisterResource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new sinister",
        Description = "Create a new sinister with the provided details",
        OperationId = "CreateSinister")]
    [SwaggerResponse(
        StatusCodes.Status201Created,
        "Sinister created successfully",
        typeof(SinisterResource))]
    [SwaggerResponse(
        StatusCodes.Status400BadRequest,
        "Invalid input data")]
    public async Task<IActionResult> CreateSinister([FromBody] CreateSinisterResource resource)
    {
        var command = CreateSinisterCommandFromResourceAssembler
            .toCommandFromResource(resource);
        
        var sinister = await sinisterCommandService
            .Handle(command);
        
        var sinisterResource =  SinisterResourceFromEntityAssembler
            .ToResourceFromEntity(sinister);
        
        return CreatedAtAction(
            nameof(GetByInsuranceId), new { insuranceId = sinister.InsuranceId.Id }, sinisterResource);
    }


}