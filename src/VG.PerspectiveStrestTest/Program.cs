using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using RestEase;
using VG.MasterpieceCatalog.Contract;

namespace VG.PerspectiveStrestTest
{
  class Program
  {
    static int errors = 0;

    static void Main(string[] args)
    {
      Console.WriteLine("Starting ...");

      long duration = 1;
      int count = 0;
     
      for (int i = 0; i < 4; i++)
      {
        ThreadPool.QueueUserWorkItem(state =>
        {
          while (true)
          {
            try
            {
              Stopwatch st = Stopwatch.StartNew();
              IMasterpieceApi masterpieceApi = RestClient.For<IMasterpieceApi>("http://localhost:12121");
              var result = masterpieceApi.GetMasterPieces();
              result.Wait();

              Interlocked.Add(ref duration, st.ElapsedMilliseconds);
              Interlocked.Increment(ref count);
            }
            catch (Exception ex)
            {
              Interlocked.Increment(ref errors);
              Console.WriteLine(ex.ToString());
            }
          }
        });
      }

      //StartAdding(ref errors);

      while (true)
      {
        Console.WriteLine($"Count : {count}, duration: {duration}, errors: {errors}, request/s: {(double)count / duration * 1000 }");
      }
    }

    private static void StartAdding()
    {
      for (int i = 0; i < 10; i++)
      {
        ThreadPool.QueueUserWorkItem(state =>
        {
          while (true)
          {
            try
            {
              IMasterpieceApi masterpieceApi = RestClient.For<IMasterpieceApi>("http://localhost:12121");
              var result = masterpieceApi.CreateMasterpiece(new CreateMasterpieceRequest()
              {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Price = 42423,
                Produced = DateTime.Parse("2019-01-01")
              });
              result.Wait();
            }
            catch (Exception ex)
            {
              Interlocked.Increment(ref errors);
              Console.WriteLine(ex.ToString());
            }
          }
        });
      }
    }
  }
}
