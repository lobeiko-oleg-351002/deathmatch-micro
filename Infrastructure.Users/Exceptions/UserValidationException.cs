namespace Infrastructure.Users.Exceptions;

public class UserValidationException : ServiceException
{
    public UserValidationException(string message) : base(message)
    {

    }
}
