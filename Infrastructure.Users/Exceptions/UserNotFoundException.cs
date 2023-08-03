namespace Infrastructure.Users.Exceptions;

public class UserNotFoundException : ServiceException
{
    public UserNotFoundException() : base("User not found") { }
}
