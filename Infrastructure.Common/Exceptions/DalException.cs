namespace Infrastructure.Common.Exceptions;

public class DalException : Exception
{
    public DalException(string message) : base(message) { }
}
