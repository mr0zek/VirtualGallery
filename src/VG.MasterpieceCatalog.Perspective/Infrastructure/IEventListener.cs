namespace VG.MasterpieceCatalog.Perspective.Infrastructure
{
  public interface IEventListener<T>
  {
    void Handle(T obj);
  }
}