namespace Infrastructure.Common.Exceptions;

public class DalCreateException : DalException
{
    public DalCreateException(string message) : base("Failed to create an entity: " + message)
    {

    }
}
