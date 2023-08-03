namespace Infrastructure.Users.Exceptions;

public class UserValidationExceptionInvalidPassword : UserValidationException
{
    public UserValidationExceptionInvalidPassword(string message) : base("Invalid Password: " + message)
    {

    }
}
