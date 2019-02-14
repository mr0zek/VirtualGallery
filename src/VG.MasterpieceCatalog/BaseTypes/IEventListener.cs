namespace VG.MasterpieceCatalog.BaseTypes
{
  public interface IEventListener<in T>
  {
    void Handle(T @event);
  }
}