using System;

namespace VG.Host
{
  public class Program
  {
    public static void Main(string[] args)
    {
      new Bootstrap().Run(args);
      Console.ReadKey();
    }    
  }
}
