namespace VG.MasterpieceCatalog.Perspective
{
  public class MasterpieceModel
  {
    public string AggregateId {get;set;}
    public int Version { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } 
  }
}