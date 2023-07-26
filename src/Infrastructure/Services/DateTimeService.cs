using deathmatch_micro.Application.Common.Interfaces;

namespace deathmatch_micro.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
