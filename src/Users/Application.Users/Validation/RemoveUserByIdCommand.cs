﻿using System.Net.Mail;
using deathmatch_micro.Application.Users.Commands;
using FluentValidation;

namespace Application.Users.Validation;
public sealed class RemoveUserByIdCommandValidator : AbstractValidator<RemoveUserByIdCommand>
{
    public RemoveUserByIdCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().Must(ValidateGuid);
    }

    private bool ValidateGuid(string id)
    {
        Guid result;
        return Guid.TryParse(id, out result); ;

    }
}