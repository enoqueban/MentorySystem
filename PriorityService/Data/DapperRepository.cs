using System.Data;
using Dapper;

namespace PriorityService.Data;

public class DapperRepository
{
    private readonly IDbConnection _connection;

    public DapperRepository(IConfiguration config)
    {
        _connection = new Npgsql.NpgsqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task CreatePriorityAsync(string title, string description, DateTime dueDate)
    {
        var sql = "INSERT INTO Priorities (Title, Description, DueDate) VALUES (@Title, @Description, @DueDate)";
        await _connection.ExecuteAsync(sql, new { Title = title, Description = description, DueDate = dueDate });
    }

    public async Task<IEnumerable<object>> GetAllPrioritiesAsync()
    {
        var sql = "SELECT Id, Title, Description, DueDate FROM Priorities ORDER BY DueDate";
        return await _connection.QueryAsync(sql);
    }

}
