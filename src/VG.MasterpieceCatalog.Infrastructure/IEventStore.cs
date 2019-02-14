using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using Dapper;
using Newtonsoft.Json;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Infrastructure
{
  internal interface IEventStore
  {
    void Save(string id, IEnumerable<IEvent> events);
    IEnumerable<IEvent> Load(string id);
  }

  class EventStore : IEventStore
  {
    private readonly string _connectionString;

    public EventStore(string connectionString)
    {
      _connectionString = connectionString;
    }
    public void Save(string id, IEnumerable<IEvent> events)
    {
      SqlConnection connection = new SqlConnection(_connectionString);
      foreach (IEvent @event in events)
      {
        JsonSerializer serializer = new JsonSerializer();
        using (StringWriter sw = new StringWriter())
        {
          serializer.Serialize(sw, @event);
          connection.Execute("insert into(id, type, data)values(@id,@data)",
            new {id, type = @event.GetType().FullName, data = sw.GetStringBuilder().ToString()});
        }
      }
    }

    public IEnumerable<IEvent> Load(string id)
    {
      throw new System.NotImplementedException();
    }
  }
}