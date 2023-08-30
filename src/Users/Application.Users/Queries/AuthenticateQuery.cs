using Application.Users.DTO.User;
using Application.Users.Interfaces;
using MediatR;

namespace deathmatch_micro.Application.Users.Queries;

public class AuthenticateQuery : IRequest<ViewUserDTO>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, ViewUserDTO>
{
    private readonly IUserService _UserService;

    public AuthenticateQueryHandler(IUserService UserService)
    {
        _UserService = UserService;
    }
    public async Task<ViewUserDTO> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
    {
        return await _UserService.GetByNameAndPassword(request.Username, request.Password);
    }
}
