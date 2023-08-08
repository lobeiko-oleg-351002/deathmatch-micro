using Application.Users.DTO.Role;
using Application.Users.DTO.User;
using Application.Users.Interfaces;
using AutoMapper;
using MediatR;

namespace deathmatch_micro.Application.Users.Commands;
public record CreateUserCommand : IRequest<Unit>
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required string RoleName { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public CreateUserCommandHandler(IUserService UserService, IMapper mapper)
    {
        _userService = UserService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.Create(_mapper.Map<CreateUserDTO>(request));
        return Unit.Value;
    }
}


