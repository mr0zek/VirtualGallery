using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

    public async Task<MasterpieceModel> GetAsync(string id)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        var ms = await connection.QueryFirstAsync<MasterpieceModelState>(
          @"select Id,Version,Name,Price,IsRemoved, CustomerId 
             from Masterpieces where Id = @Id", new {id});
        return ms.ConvertToMasterpieceModel();
      }
    }

    public async Task<MasterpiecesModel> GetManyAsync()
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        return new MasterpiecesModel((await connection.QueryAsync<MasterpieceModelState>(
          @"select Id,Version,Name,Price, IsRemoved, CustomerId from Masterpieces"))
          .Select(ms => ms.ConvertToMasterpieceModel()));
      }
    }

    internal class MasterpieceModelState
    {
      public string Id { get; set; }
      public int Version { get; set; }
      public string Name { get; set; }
      public decimal Price { get; set; }
      public bool IsRemoved { get; set; }
      public string CustomerId { get; set; }

      public MasterpieceModel ConvertToMasterpieceModel()
      {
        return new MasterpieceModel()
        {
          Name = this.Name,
          Price = this.Price,
          Id = this.Id,
          Version = this.Version,
          IsAvailable = !this.IsRemoved
        };
      }
    }
  }
}

  