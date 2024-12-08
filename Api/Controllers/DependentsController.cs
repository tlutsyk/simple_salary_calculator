using Api.Converters;
using Api.Dtos.Dependent;
using CSharpFunctionalExtensions;
using DAL.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

// todo: Do we really need this controller???
[ApiController]
[Route("api/v1/dependents")]
public class DependentsController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get dependent by id")]
    public async Task<ActionResult<DependentDto>> Get(int id, CancellationToken cancellationToken)
    {
        var request = new GetDependentByIdRequest(id);
        var response = await sender.Send(request, cancellationToken);

        return response.Match(
            Some: dependent => (ActionResult<DependentDto>)dependent.ToDto(),
            None: () => NotFound());
    }

    // todo: use object instead if list<DependentDto>;
    // add pagination and filters;
    [HttpGet]
    [SwaggerOperation(Summary = "Get all dependents")]
    public async Task<ActionResult<List<DependentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var request = new GetDependentByFilterRequest();
        var response = await sender.Send(request, cancellationToken);

        var dto = response
            .Select(d => d.ToDto())
            .ToArray();

        return Ok(dto);
    }
}
