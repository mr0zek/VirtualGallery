namespace VG.Notification.ExternalInterfaces
{
  public interface IEvent
  {
    int Version { get; }
    string AggregateId { get; set; }
  }
}