namespace Infrastructure.Common.Exceptions;

public class DalDeleteException : DalException
{
    public DalDeleteException(string message) : base("Failed to delete an entity: " + message)
    {

    }
}
