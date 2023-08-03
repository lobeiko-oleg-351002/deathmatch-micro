using deathmatch_micro.Domain;

namespace Infrastructure.Common.Logging;

public interface ILogMessageManager<TEntity>
    where TEntity : BaseEntity
{
    public void LogEntityCreation(TEntity entity);

    public void LogEntityUpdate(TEntity entity);

    public void LogSuccess();

    public void LogGetAll();

    public void LogFailure(string message);

    public void LogDelete(Guid id);

    public void LogGet(Guid id);

    public void LogCustomMessage(string message);
}
