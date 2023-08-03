namespace Infrastructure.Users.Exceptions;

public class UserValidationExceptionUserIsNull : UserValidationException
{
    public UserValidationExceptionUserIsNull() : base("User is null")
    {

    }
}
