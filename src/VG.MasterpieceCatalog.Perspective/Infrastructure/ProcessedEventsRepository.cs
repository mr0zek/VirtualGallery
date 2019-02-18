using System.Data.SqlClient;
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

    public int GetLastProcessedEventId()
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return connection.QueryFirst<int>(@"select lastEventId from HandledEvents");
      }
    }

    public void SetLastProcessedEventId(int id)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Execute(@"update HandledEvents set lastEventId = @id",new { id });
      }
    }
  }
}