namespace Infrastructure.Common.Exceptions;

public class ItemNotFoundException : DalException
{
    public ItemNotFoundException() : base("Item not found")
    {

    }
}
