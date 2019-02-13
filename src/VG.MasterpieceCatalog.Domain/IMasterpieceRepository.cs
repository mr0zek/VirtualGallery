namespace VG.MasterpieceCatalog.Domain
{
  public interface IMasterpieceRepository
  {
    Masterpiece Get(MasterpieceId id);
    void Save(Masterpiece masterpiece);
    void Delete(Masterpiece masterpiece);
  }
}