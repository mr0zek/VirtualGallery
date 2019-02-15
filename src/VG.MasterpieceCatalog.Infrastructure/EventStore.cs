using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Newtonsoft.Json;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal class EventStore : IEventStore
  {
    private readonly string _connectionString;

    public EventStore(string connectionString)
    {
      _connectionString = connectionString;
    }
    public void Save(string aggregateId, IEnumerable<IEvent> events)
    {
      SqlConnection connection = new SqlConnection(_connectionString);
      foreach (IEvent @event in events)
      {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
          TypeNameHandling = TypeNameHandling.All
        };

        string strJson = JsonConvert.SerializeObject(@event, settings);
        connection.Execute("insert into Events(aggregateId, data)values(@aggregateId,@data)",
          new { aggregateId = @event.AggregateId, data = strJson });
      }
    }

    public IEnumerable<IEvent> Load(string aggregateId)
    {
      JsonSerializerSettings settings = new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All
      };

      SqlConnection connection = new SqlConnection(_connectionString);
      return connection.Query<string>("select data from Events where aggregateId = @aggregateId",
        new { aggregateId }).Select(f => JsonConvert.DeserializeObject<IEvent>(f, settings));
    }

    public IEnumerable<Event> GetFrom(int lastEventId, int count)
    {
      JsonSerializerSettings settings = new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All
      };

      SqlConnection connection = new SqlConnection(_connectionString);
      return connection.Query<dynamic>("select id, data from Events where id > @lastEventId and id < @finalId", 
          new { lastEventId, finalId = lastEventId+count })
        .Select(f =>
        {
          IEvent @event = JsonConvert.DeserializeObject<IEvent>(f.Data, settings);
          return new Event(f.Id, @event);
        });
    }
  }
}