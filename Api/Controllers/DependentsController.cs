using Api.Dtos.Dependent;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/dependents")]
public class DependentsController : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get dependent by id")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all dependents")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
