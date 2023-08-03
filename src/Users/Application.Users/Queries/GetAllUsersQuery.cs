using Application.Users.DTO.User;
using Application.Users.Interfaces;
using MediatR;

namespace deathmatch_micro.Application.Users.Queries;

public class GetAllUsersQuery : IRequest<IList<ViewUserDTO>>
{
}

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<ViewUserDTO>>
{
    private readonly IUserService _UserService;

    public GetAllUsersQueryHandler(IUserService UserService)
    {
        _UserService = UserService;
    }
    public async Task<IList<ViewUserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _UserService.GetAll();
    }
}
