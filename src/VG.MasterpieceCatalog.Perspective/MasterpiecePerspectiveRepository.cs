using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using VG.MasterpieceCatalog.Contract;

namespace VG.MasterpieceCatalog.Perspective
{
  class MasterpiecePerspectiveRepository : IMasterpiecePerspectiveRepository
  {
    private readonly string _connectionString;

    public MasterpiecePerspectiveRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public async Task<MasterpieceModel> GetAsync(string aggregateId)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return await connection.QueryFirstAsync<MasterpieceModel>(
           @"select AggregateId,Version,Name,Price from Masterpieces where AggregateId = @AggregateId", new { aggregateId });
      }
    }

    public async Task<MasterpiecesModel> GetManyAsync()
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return new MasterpiecesModel(await connection.QueryAsync<MasterpieceModel>(@"select AggregateId,Version,Name,Price from Masterpieces"));
      }
    }
  }
}