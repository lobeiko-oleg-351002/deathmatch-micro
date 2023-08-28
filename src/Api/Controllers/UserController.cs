using Application.Users.Queries;
using deathmatch_micro.Application.Users.Commands;
using deathmatch_micro.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("user")]
    public async Task CreateUser([FromForm] CreateUserCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    [HttpDelete]
    [Route("user")]
    public async Task DeleteUser(RemoveUserByIdCommand cmd)
    {
        await _mediator.Send(cmd);
    }

    //  [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("users")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("roles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _mediator.Send(new GetAllRolesQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("user/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetUserQuery { Id = id });
        return Ok(result);
    }
}
