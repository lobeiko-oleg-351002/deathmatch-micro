namespace Infrastructure.Common.Exceptions;

public class NoElementsException : DalException
{
    public NoElementsException() : base("No elements in Database")
    {

    }
}
