using System.Data;
using Npgsql;

namespace Infrastructure.DbContext;

public class DbContext : IDbContext
{
    private NpgsqlConnection _connection = null!;
    private NpgsqlTransaction? _transaction;

    public IDbConnection GetConnection()
    {
        return _connection;
    }
    
    public async Task CreateConnectionAsync(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        await _connection.OpenAsync();
    }

    public async Task CloseConnectionAsync()
    {
        if (_connection?.State == ConnectionState.Open)
        {
            await _connection.CloseAsync();
        }
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _connection.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync();

            await _transaction.DisposeAsync();

            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
       
            await _transaction.DisposeAsync();

            _transaction = null;
        }
    }
}