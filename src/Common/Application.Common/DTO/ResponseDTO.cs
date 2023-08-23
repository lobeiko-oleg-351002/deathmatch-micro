namespace Application.Common.DTO;

public abstract record ResponseDTO
{
    public required Guid Id { get; set; }
}
