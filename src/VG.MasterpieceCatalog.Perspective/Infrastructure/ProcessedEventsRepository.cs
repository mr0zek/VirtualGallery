using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  class ProcessedEventsRepository : IProcessedEventsRepository
  {
    private readonly string _connectionString;

    public ProcessedEventsRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public async Task<int> GetLastProcessedEventIdAsync()
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return await connection.QueryFirstAsync<int>(@"select lastEventId from HandledEvents");
      }
    }

    public async Task SetLastProcessedEventIdAsync(int id)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        await connection.ExecuteAsync(@"update HandledEvents set lastEventId = @id",new { id });
      }
    }
  }
}