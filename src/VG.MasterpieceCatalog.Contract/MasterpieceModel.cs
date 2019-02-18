namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceModel
  {
    public string Id { get; set; }
    public int Version { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
  }
}