using deathmatch_micro.WebUI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace deathmatch_micro.WebUI.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
