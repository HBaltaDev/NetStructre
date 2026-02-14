using System.Data;

namespace Infrastructure.DbContext;

public interface IDbContext
{
    public IDbConnection GetConnection();
    
    public Task CreateConnectionAsync(string connectionString);
    
    public Task CloseConnectionAsync();

    public Task BeginTransactionAsync();

    public Task CommitAsync();
    
    public Task RollbackAsync();
}