using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Newtonsoft.Json;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure.SqlEventStore
{
  internal class EventStore : IEventStore
  {
    private readonly string _connectionString;

    public EventStore(string connectionString)
    {
      _connectionString = connectionString;
    }
    public void Save(string aggregateId, IEnumerable<IEvent> events, int? expectedVersion)
    {      
      int? i = GetCurrentVersion(aggregateId);
      if (i.HasValue && expectedVersion.HasValue && i.Value != expectedVersion.Value)
      {
        throw new ConcurrencyException(i.Value, expectedVersion.Value);
      }

      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        foreach (IEvent @event in events)
        {
          JsonSerializerSettings settings = new JsonSerializerSettings
          {
            TypeNameHandling = TypeNameHandling.All
          };
          i++;
          string strJson = JsonConvert.SerializeObject(@event, settings);
          connection.Execute("insert into Events(aggregateId, version, data)values(@aggregateId,@version,@data)",
            new {aggregateId = @event.AggregateId, version = i, data = strJson});
        }
      }
    }

    private int GetCurrentVersion(string aggregateId)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return connection.Query<int>(
          "select top 1 version from Events where aggregateId = @aggregateId order by version desc",
          new {aggregateId}).FirstOrDefault();
      }
    }


    public IEnumerable<IEvent> Load(string aggregateId)
    {
      JsonSerializerSettings settings = new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All
      };

      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return connection.Query<string>("select data from Events where aggregateId = @aggregateId",
          new {aggregateId}).Select(f => JsonConvert.DeserializeObject<IEvent>(f, settings));
      }
    }

    public bool HasEvents(string aggregateId)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return connection.Query("select 1 from Events where aggregateId = @aggregateId", new {aggregateId}).Any();
      }
    }

    public IEnumerable<Event> GetFrom(int? lastEventId, int count)
    {
      JsonSerializerSettings settings = new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All
      };
      if (lastEventId == null)
      {
        lastEventId = 0;
      }

      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return connection.Query<dynamic>("select id,version,data from Events where id > @lastEventId and id < @finalId",
            new {lastEventId, finalId = lastEventId + count})
          .Select(f =>
          {
            IEvent @event = JsonConvert.DeserializeObject<IEvent>(f.data, settings);
            return new Event((int) f.id, (int) f.version, @event);
          }).ToList();
      }
    }
  }
}