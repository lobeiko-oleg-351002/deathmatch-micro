using Application.Users.DTO.Role;
using Application.Users.Interfaces;
using MediatR;

namespace Application.Users.Queries;
public class GetAllRolesQuery : IRequest<IList<ViewRoleDTO>>
{
}

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IList<ViewRoleDTO>>
{
    private readonly IRoleService _RoleService;

    public GetAllRolesQueryHandler(IRoleService RoleService)
    {
        _RoleService = RoleService;
    }
    public async Task<IList<ViewRoleDTO>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        return await _RoleService.GetAll();
    }
}
