using System;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Command
{
  public class PostBuyerRequest
  {
    public Guid CustomerId { get; set; }
  }
}