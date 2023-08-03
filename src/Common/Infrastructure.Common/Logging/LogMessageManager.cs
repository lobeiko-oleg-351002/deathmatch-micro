using deathmatch_micro.Domain;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Common.Logging;

public class LogMessageManager<TEntity> : ILogMessageManager<TEntity>
        where TEntity : BaseEntity
{
    private readonly ILogger<TEntity> _logger;

    public LogMessageManager(ILogger<TEntity> logger)
    {
        _logger = logger;
    }

    public void LogDelete(Guid id)
    {
        _logger.LogInformation("Delete " + typeof(TEntity).FullName + ": \n" + id.ToString());
    }

    public void LogGet(Guid id)
    {
        _logger.LogInformation("Get " + typeof(TEntity).FullName + ": \n" + id.ToString());
    }

    public void LogEntityCreation(TEntity entity)
    {
        _logger.LogInformation("Create " + typeof(TEntity).FullName + ": \n" + JsonSerializer.Serialize(entity));
    }

    public void LogEntityUpdate(TEntity entity)
    {
        _logger.LogInformation("Update " + typeof(TEntity).FullName + ": \n" + JsonSerializer.Serialize(entity));
    }

    public void LogGetAll()
    {
        _logger.LogInformation("GetAll " + typeof(TEntity).FullName);
    }

    public void LogFailure(string message)
    {
        _logger.LogInformation("Failure: " + message);
    }

    public void LogSuccess()
    {
        _logger.LogInformation("Success");
    }

    public void LogCustomMessage(string message)
    {
        _logger.LogInformation(message);
    }
}
