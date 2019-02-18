using System;
using System.Data.SqlClient;
using System.Linq;
using Autofac;
using Dapper;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;
using VG.MasterpieceCatalog.Infrastructure.SqlEventStore;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class MasterpieceRepository : IMasterpieceRepository
  {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly string _connectionString;

    public MasterpieceRepository(IDateTimeProvider dateTimeProvider, string connectionString)
    {
      _dateTimeProvider = dateTimeProvider;
      _connectionString = connectionString;
    }

    public Masterpiece Get(MasterpieceId id)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        var result =  connection.QueryFirstOrDefault<dynamic>(
          "select AggregateId, Name, Price, Version, Produced from Events where aggregateId = @aggregateId order by version desc",
          new { aggregateId = id });
        return new Masterpiece(result.AggregateId, result.Name, result.Price, result.Version, _dateTimeProvider);
      }      
    }

    public void Save(Masterpiece masterpiece, int? expectedVersion)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Execute(
          @"update Masterpieces 
            set AggregateId = @masterpiece.AggregateId, 
                Name = @masterpiece.Name, 
                Price = @masterpiece.Price, 
                Version = @masterpiece.Version, 
                Produced = @masterpiece.Produced 
            where aggregateId = @masterpiece.AggregateId and Version = @expectedVersion", new { masterpiece, expectedVersion });
      }
    }
  }
}
