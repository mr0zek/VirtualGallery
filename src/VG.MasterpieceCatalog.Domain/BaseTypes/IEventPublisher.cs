namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  internal interface IEventPublisher
  {
    void Publish(IEvent @event);
  }
}