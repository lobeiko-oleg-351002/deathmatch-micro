namespace Infrastructure.Users.Exceptions;

public class UserValidationExceptionInvalidName : UserValidationException
{
    public UserValidationExceptionInvalidName(string message) : base("Invalid name: " + message)
    {

    }
}
