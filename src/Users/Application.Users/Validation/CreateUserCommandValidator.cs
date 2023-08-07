using System.Net.Mail;
using deathmatch_micro.Application.Users.Commands;
using FluentValidation;

namespace Application.Users.Validation;
public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private const int MinFieldLength = 3;
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Role).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(MinFieldLength);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(MinFieldLength);
        RuleFor(x => x.Email).NotEmpty().Must(IsEmailValid).WithMessage("Invalid email");
    }

    private bool IsEmailValid(string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
