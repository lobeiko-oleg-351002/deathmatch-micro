namespace Infrastructure.Users.Exceptions;

public class UserValidationExceptionInvalidEmail : UserValidationException
{
    public UserValidationExceptionInvalidEmail() : base("Invalid Email")
    {

    }
}
