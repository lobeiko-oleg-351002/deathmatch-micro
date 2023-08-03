﻿using Application.Users.Interfaces;
using MediatR;

namespace deathmatch_micro.Application.Users.Commands;
public record RemoveUserByIdCommand : IRequest<Unit>
{
    public readonly Guid Id;

    public RemoveUserByIdCommand(Guid id)
    {
        Id = id;
    }
}

public class RemoveUserCommandHandler : IRequestHandler<RemoveUserByIdCommand, Unit>
{
    private readonly IUserService _UserService;
    public RemoveUserCommandHandler(IUserService UserService)
    {
        _UserService = UserService;
    }

    public async Task<Unit> Handle(RemoveUserByIdCommand request, CancellationToken cancellationToken)
    {
        await _UserService.Delete(request.Id);
        return Unit.Value;
    }
}