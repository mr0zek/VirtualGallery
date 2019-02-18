using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace VG.MasterpieceCatalog.Perspective
{
  class MasterpiecePerspectiveRepository : IMasterpiecePerspectiveRepository
  {
    private readonly string _connectionString;

    public MasterpiecePerspectiveRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public void Add(MasterpieceModel model)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Execute(@"insert into MasterpiecesPerspective(AggregateId,Version,Name,Price)
                             values(@AggregateId,@Version,@Name,@Price)", model);
      }
    }

    public void Save(MasterpieceModel model)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        connection.Execute(@"update MasterpiecesPerspective set
                              Version = @Version,
                              Name = @Name,
                              Price = @Price 
                              where AggregateId = @AggregateId", model);
      }
    }

    public MasterpieceModel Get(string aggregateId)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return connection.QueryFirst<MasterpieceModel>(
           @"select AggregateId,Version,Name,Price from MasterpiecesPerspective where AggregateId = @AggregateId", new { aggregateId });
      }
    }

    public MasterpiecesModel GetMany()
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return new MasterpiecesModel(connection.Query<MasterpieceModel>(@"select AggregateId,Version,Name,Price from MasterpiecesPerspective"));
      }
    }
  }
}