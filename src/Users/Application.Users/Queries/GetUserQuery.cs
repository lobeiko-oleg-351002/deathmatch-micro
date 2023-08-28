using Application.Users.DTO.User;
using Application.Users.Interfaces;
using MediatR;

namespace deathmatch_micro.Application.Users.Queries;

public class GetUserQuery : IRequest<ViewUserDTO>
{
    public required Guid Id { get; set; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ViewUserDTO>
{
    private readonly IUserService _UserService;

    public GetUserQueryHandler(IUserService UserService)
    {
        _UserService = UserService;
    }
    public async Task<ViewUserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _UserService.Get(request.Id);
    }
}
