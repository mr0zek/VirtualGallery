using System;
using System.Data.SqlClient;
using System.Linq;
using Autofac;
using Dapper;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

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
        var result = connection.QueryFirstOrDefault<MasterpieceState>(
          "select Id, Name, Price, Version, Produced, IsRemoved from Masterpieces where Id = @id",
          new { id = id.ToString() });
        if (result == null)
        {
          throw new IndexOutOfRangeException(id);
        }
        return new Masterpiece(result, _dateTimeProvider);
      }
    }

    public void Save(Masterpiece masterpiece)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
      {
        MasterpieceState state = masterpiece.GetState();
        if (state.Version == 0)
        {
          connection.Execute(
            @"insert into Masterpieces(Id,Name,Price,Version,Produced, IsRemoved)Values(@Id,@Name,@Price,@Version,@Produced, @IsRemoved)",
            new
            {
              state.Id,
              Version = state.Version + 1,
              state.Name,
              state.Price,
              state.Produced,
              state.IsRemoved
            });
        }
        else
        {
          int rowsAffected = connection.Execute(
            @"update Masterpieces 
            set Id = @Id, 
                Name = @Name, 
                Price = @Price, 
                Version = @Version, 
                Produced = @Produced,
                IsRemoved = @IsRemoved
            where Id = @Id and Version = @PrevVersion",
            new
            {
              state.Id,
              Version = state.Version + 1,
              PrevVersion = state.Version,
              state.Name,
              state.Price,
              state.Produced,
              state.IsRemoved
            });
          if (rowsAffected == 0)
          {
            throw new ConcurrencyException(state.Version);
          }
        }
      }
    }
  }
}
