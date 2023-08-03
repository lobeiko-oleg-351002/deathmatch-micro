namespace Infrastructure.Users.Exceptions;

public class UserValidationExceptionRoleIsNull : UserValidationException
{
    public UserValidationExceptionRoleIsNull() : base("Role is null")
    {

    }
}
